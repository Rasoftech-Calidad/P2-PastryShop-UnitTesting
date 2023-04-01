window.addEventListener('DOMContentLoaded', function(event){

    function editFormCategory()
    {
        debugger;
        let name = document.querySelector('#name_input').value;
        let description = document.querySelector('#description_input').value;
        let imageFile = document.querySelector('#form-wrapper #post-form .property-wrapper .custom-file-input').files[0];
        let imageUrl = document.querySelector('#image_input').value;
        
        const formData = new FormData();
        formData.append('Name', name);
        formData.append('Description', description);
        formData.append('ImageURL',imageUrl);
        formData.append('Image', imageFile);
        
        let url = `${baseUrl}/categories/${categoryId}/Form`;
        fetch(url, { 
            method: 'PUT',
            body: formData
            }).then((data)=>{
                if(data.status === 200){
                    alert('edited');
                    window.location.href = "categories.html";
                } else {
                    data.text()
                    .then((error)=>{
                        alert('edited');
                        window.location.href = "categories.html";
                    });
                }
            });/*.catch((errormessage) => {
                alert(errormessage);
            });*/   
    }
    
    async function fetchCategory()
    {//eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJFbWFpbCI6I…ldCJ9.txBWs5oV-j-mRnivMzsKSBIqqA--xzXdr4D0NDSzgHI
        //debugger;
        const url = `${baseUrl}/categories/${categoryId}`;
        let jwtoken = sessionStorage.getItem("jwt");
        let response = await fetch(url, {
            headers: { 
                "Content-Type": "application/json; charset=utf-8",
                "Authorization": `Bearer ${jwtoken}`  
            },
            method: 'GET'
        });
        try{
            if(response.status == 200){
                let category = await response.json();
                let backImageUrl = category.imagePath? 
                    `${baseRawUrl}/${category.imagePath}`.replace(/\\/g, "/") : category.imageUrl;
                let categoryCard = `
                    <div id="form-image" style="background: url(${backImageUrl})">
                    </div>
                    <div id="post-form">
                        <h2>Edition Info</h2>
                        <div class="property-wrapper"> 
                            <label for="name_input">Name</label>
                            <input type="text" name="name_input_name" id="name_input" placeholder="${category.name}" value="${category.name}">
                        </div>

                        <div class="property-wrapper"> 
                            <label for="description_input">Description</label>
                            <input type="text" name="name_input_description" id="description_input" placeholder="${category.description}" value="${category.description}">
                        </div>
                        
                        <div class="property-wrapper"> 
                            <label for="image_input">ImageURL</label>
                            <input type="text" name="name_input_image" id="image_input" placeholder="${category.imageUrl}" value="${category.imageUrl}">
                        </div>

                        <div class="property-wrapper">
                            <label for="image_file_input">Image File</label>
                            <input type="file" name="image" id="image_file_input" class="edit-input custom-file-input" placeholder="${category.imagePath}" value="${category.imagePath}>
                        </div>

                        <div class="submit-container">
                            <button class="edit-submit">Edit</button>
                        </div>
                    </div>
                `;
                document.querySelector('#form-wrapper').innerHTML = categoryCard;
                
                let editButton = document.querySelector('.edit-submit'); /*.delete-btn[data-delete-product-id]*/ 
                editButton.addEventListener('click', editFormCategory);//editCategory
                
            }
        } catch(error){
            let errorText = await error.text;
            alert(errorText);
        }
    }

    const baseRawUrl = 'http://localhost:3030';
    const baseUrl = 'http://localhost:3030/api';
    let queryParams = window.location.search.split('?');
    let categoryId= queryParams[1].split('=')[1];
    fetchCategory();
});