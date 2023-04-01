

window.addEventListener('DOMContentLoaded', function(event){

    function goToEditProduct(){
        let productId = this.dataset.editProductId;
        window.location.href = `./editProduct.html?categoryId=${categoryId}&productId=${productId}`;
    }

    function goToCreateProduct(){
        window.location.href = `./createProduct.html?categoryId=${categoryId}`;
    }

    function DeleteProduct(event){

        let productId = this.dataset.deleteProductId;

        let url = `${baseUrl}/products/${productId}`;
        fetch(url, { 
        method: 'DELETE' 
        }).then((data)=>{
            if(data.status === 200){
                alert('deleted');
                window.location.reload(); 
            }
        }); 
    }

    function cardsSpecificFilter(){
        debugger;
        let filter = document.querySelector('.filter-container .specific-filter-wrapper #specific-filter').value;
        let selector = (filter==="name")? '.card-name' : (filter==="description")? '.card-description' : 'none';
        let val = document.querySelector('#specific-filter-input').value;
        val = val.toUpperCase();
        let cards = document.querySelectorAll('.card');
    
        if(selector != "none"){
            cards.forEach(card => {
                debugger;
                let name = card.querySelector(`.card-properties ${selector}`).innerText.toUpperCase();
                if(!name.includes(val))
                    card.style.display = "none";
                else{
                    card.style.display = "block";
                }
            });
        }
        

    }
    
    async function fetchProducts()
    {
        const url = `${baseUrl}/products`;
        let response = await fetch(url);

        try{
            if(response.status == 200){
                let data = await response.json();
                let productCards = data.map(product => { 
                let backImageUrl = product.imagePath? 
                `${baseRawUrl}/${product.imagePath}`.replace(/\\/g, "/") : product.imageUrl;    
                return `
                <div class="card" style="background: url(${backImageUrl})">
                    <div class="card-top">
                        <div class="card-properties"> 
                            <div class="card-name"> 
                                <h2>${product.name}</h2> <!--max35 chars-->
                            </div>
                            <div class="card-description"> 
                                <p>${product.description}</p> <!--max270 chars-->
                            </div>
                            <div class="card-price"> 
                                <p><span class="price"></span>${product.price}<span20 class="coin">Bs</span20></p>
                            </div>
                        </div>
                    </div>
                
                    <div class="card-bottom">
                        <div class="btn-wrapper">
                            <div class="edit-container" data-edit-product-id="${product.id}">
                                <button class="btn edit-btn">edit</button>
                                <div class="fill-btn"> </div>
                            </div>
                            <div class="delete-container" data-delete-product-id="${product.id}">
                                <button class="btn delete-btn">delete</button>
                                <div class="fill-btn"> </div>
                            </div>
                        </div>
                    </div>
                    
                    <div class="card-overlay"></div>
                </div>`});

                let productsContent = productCards.join('');
                document.getElementById('cards-container').innerHTML = productsContent;
                
                let delButtons = document.querySelectorAll('#cards-container .card .card-bottom .btn-wrapper .delete-container'); /*.delete-btn[data-delete-product-id]*/ 
                for (let button of delButtons) {
                    button.addEventListener('click', DeleteProduct);
                }

                let editButtons = document.querySelectorAll('#cards-container .card .card-bottom .btn-wrapper .edit-container'); /*.delete-btn[data-delete-product-id]*/ 
                for (let button of editButtons) {
                    button.addEventListener('click', goToEditProduct);
                }

                let createButton = document.querySelector('#navigation-container .create-container');//('.navigation .create-container');
                createButton.addEventListener('click', goToCreateProduct)

                let specific_filter_btn = document.querySelector('#specific-filter-btn');
                specific_filter_btn.addEventListener('click', cardsSpecificFilter)


            }
        } catch(error){
            const errorText = await error.text;
            console.log(errorText);
        }
    }

    const baseRawUrl = 'http://localhost:3030';
    const queryParams = window.location.search.split('?');
    const categoryId = queryParams[1].split('=')[1];
    const baseUrl = `http://localhost:3030/api/categories/${categoryId}`;
    fetchProducts();
});
