
window.addEventListener('DOMContentLoaded', function(event){

    function goToProducts(){
        let categoryId = this.dataset.cardCategoryId;
        window.location.href = `../Products/products.html?categoryId=${categoryId}`;
    }

    function goToEditCategory(){
        let categoryId = this.dataset.editCategoryId;
        window.location.href = `../Categories/editCategory.html?categoryId=${categoryId}`;
    }

    function goToCreateCategory(){
        window.location.href = `createCategory.html`;
    }

    function DeleteCategory(event){
        let categoryId = this.dataset.deleteCategoryId;
        let url = `${baseUrl}/categories/${categoryId}`;
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
        let filter = document.querySelector('#navigation-container .specific-filter-wrapper #specific-filter').value;
        let description = (filter==="description")? '.card-description' : 'none';
        let selector = (filter==="name")? '.card-name' : description;
        let val = document.querySelector('#specific-filter-input').value;//"cake";
        val = val.toUpperCase();
        let cards = document.querySelectorAll('.card');
    
        if(selector != "none"){
            cards.forEach(card => {
                let name = card.querySelector(`.card-properties ${selector}`).innerText.toUpperCase();
                if(!name.includes(val))
                    card.style.display = "none";
                else{
                    card.style.display = "block";
                }
            });
        }
    }

    async function fetchCategories()
    {
        const url = `${baseUrl}/categories`;
        let errorText = ""
        let response = await fetch(url, { 
            method: 'GET',
            "Authorization": `Bearer ${sessionStorage.getItem("jwt")}`  // AUTHORIZATION:  Encoded Token JWT
            });
        try{//cardCategoryId
            if(response.status == 200){
                let data = await response.json();
                let productCards = data.map(category => {
                    let backImageUrl = category.imagePath? 
                    `${baseRawUrl}/${category.imagePath}`.replace(/\\/g, "/") : category.imageUrl;
                    return `
                    <div class="card" style="background: url(${backImageUrl})">
                        <div class="card-top" >
                            <div class="card-properties"> 
                                <div class="card-name"> 
                                    <h2>${category.name}</h2> <!--max35 chars-->
                                </div>
                                <div class="card-description"> 
                                    <p>${category.description}</p> <!--max270 chars-->
                                </div>
                            </div>
                        </div>
                    
                        <div class="card-bottom">
                            <div class="btn-wrapper">
                                <div class="edit-container" data-edit-category-id="${category.id}">
                                    <button class="btn edit-btn">edit</button>
                                    <div class="fill-btn"> </div>
                                </div>
                                <div class="delete-container" data-delete-category-id="${category.id}">
                                    <button class="btn delete-btn">delete</button>
                                    <div class="fill-btn"> </div>
                                </div>
                            </div>
                        </div>
                        
                        <div class="card-overlay" data-card-category-id="${category.id}"></div>
                    </div>`});
                
                let productsContent = productCards.join('');
                document.getElementById('cards-container').innerHTML = productsContent;
                
                let delButtons = document.querySelectorAll('#cards-container .card .card-bottom .btn-wrapper .delete-container'); /*.delete-btn[data-delete-product-id]*/ 
                for (let button of delButtons) {
                    button.addEventListener('click', DeleteCategory);
                }
                let editButtons = document.querySelectorAll('#cards-container .card .card-bottom .btn-wrapper .edit-container'); /*.delete-btn[data-delete-product-id]*/ 
                for (let button of editButtons) {
                    button.addEventListener('click', goToEditCategory);
                }
                let createButton = document.querySelector('#navigation-container .create-container');//('.navigation .create-container');
                createButton.addEventListener('click', goToCreateCategory)
                
                let productCard = document.querySelectorAll('#cards-container .card .card-overlay');//.card-top');
                for (let card of productCard) {
                    card.addEventListener('click', goToProducts);
                }
                
                let specific_filter_btn = document.querySelector('#specific-filter-btn');
                specific_filter_btn.addEventListener('click', cardsSpecificFilter)
                
            }
        } catch(error){
            errorText = await error.text;
        }
    }

    const baseRawUrl = 'http://localhost:3030';
    const baseUrl = 'http://localhost:3030/api';
    fetchCategories();
});

//https://www.freecodecamp.org/news/a-practical-es6-guide-on-how-to-perform-http-requests-using-the-fetch-api-594c3d91a547/