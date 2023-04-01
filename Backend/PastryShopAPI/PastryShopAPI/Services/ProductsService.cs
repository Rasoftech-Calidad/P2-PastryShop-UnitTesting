using AutoMapper;
using PastryShopAPI.Data.Entities;
using PastryShopAPI.Exceptions;
using PastryShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PastryShopAPI.Services
{
    public class ProductsService : IProductsService
    {
        readonly IPastryShopRepository _pastryShopRepository;
        readonly IMapper _mapper;

        public ProductsService(IPastryShopRepository pastryShopRepository, IMapper mapper)
        {
            _pastryShopRepository = pastryShopRepository;
            _mapper = mapper;
        }

        public async Task<ProductModel> CreateProductAsync(long categoriyId, ProductModel newProduct)
        {
            await ValidateCategoryAsync(categoriyId);
            newProduct.CategoryId = categoriyId;
            var productEntity = _mapper.Map<ProductEntity>(newProduct);

            _pastryShopRepository.CreateProduct(categoriyId, productEntity);

            var result = await _pastryShopRepository.SaveChangesAsync();

            if (!result)
            {
                throw new InvalidOperationItemException($"Could not create new product name: {newProduct.Name}");
            }

            return _mapper.Map<ProductModel>(productEntity);
        }

        public async Task<bool> DeleteProductAsync(long categoriyId, long productId)
        {
            await ValidateCategoryAndProductAsync(categoriyId, productId);
            await _pastryShopRepository.DeleteProductAsync(categoriyId, productId);

            var result = await _pastryShopRepository.SaveChangesAsync();

            if (!result)
            {
                throw new InvalidOperationItemException($"Could not delete product ID: {productId}");
            }

            return true;
        }

        public async Task<ProductModel> GetProductAsync(long categoriyId, long productId)
        {
            await ValidateCategoryAsync(categoriyId);
            var productEntity = await _pastryShopRepository.GetProductAsync(categoriyId, productId);
            if (productEntity == null)
            {
                throw new NotFoundItemException($"The product with id: {productId} does not exist in category with id:{categoriyId}.");
            }

            var productModel = _mapper.Map<ProductModel>(productEntity);

            productModel.Id = categoriyId;
            return productModel;
        }

        public async Task<IEnumerable<ProductModel>> GetProductsAsync(long categoriyId)
        {
            await ValidateCategoryAsync(categoriyId);
            var products = await _pastryShopRepository.GetProductsAsync(categoriyId);
            return _mapper.Map<IEnumerable<ProductModel>>(products);
        }

        public async Task<ProductModel> UpdateProductAsync(long categoriyId, long productId, ProductModel updatedProduct)
        {
            await ValidateCategoryAndProductAsync(categoriyId, productId);
            await _pastryShopRepository.UpdateProductAsync(categoriyId, productId, _mapper.Map<ProductEntity>(updatedProduct));
            var result = await _pastryShopRepository.SaveChangesAsync();

            if (!result)
            {
                throw new InvalidOperationItemException($"Could not update product: {updatedProduct.Name} with id: {updatedProduct.Id}");
            }

            return updatedProduct;
        }

        private async Task ValidateCategoryAsync(long categoriyId)
        {
            var category = await _pastryShopRepository.GetCategoryAsync(categoriyId); // Reemplazar con GetCategoryAndProducts()  hacer este endpoint!
            if (category == null)
            {
                throw new NotFoundItemException($"The category with id: {categoriyId} does not exists.");
            }
        }

        private async Task<ProductModel> ValidateCategoryAndProductAsync(long categoriyId, long productId)
        {
            var product = await GetProductAsync(categoriyId, productId);
            return product;
        }

        // FOR COMBOS Creation
        public async Task<IEnumerable<ProductModel>> GetAllProductsAsync(long categoriyId)
        {
            await ValidateCategoryAsync(categoriyId);
            var products = await _pastryShopRepository.GetAllProductsAsync();
            return _mapper.Map<IEnumerable<ProductModel>>(products);
        }
    }
}