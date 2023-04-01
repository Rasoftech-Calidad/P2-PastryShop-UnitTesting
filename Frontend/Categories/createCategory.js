window.addEventListener('DOMContentLoaded', function(event){

    function validProperties(name, description, image, imageFile){
        debugger;
        if (name === "" || description === "" || (image === "" && !imageFile)){
            alert("Not valid values. Please fill all the fields");
            return false;
        }
        else{
            return true;
        }
    }
    
    function PostFormCategory(event)
    {
        debugger;
        event.preventDefault();
        let url = `${baseUrl}/categories/Form`;
        /*if(!event.currentTarget.dtName.value)  IF no name is detected it changes the background to red as an alert
        {
            event.currentTarget.dtName.style.backgroundColor = 'red';
            return;
        }*/
        
        let name = document.querySelector('#name_input').value;
        let description = document.querySelector('#description_input').value;
        let imageFile = document.querySelector('#form-wrapper #post-form .property-wrapper .custom-file-input').files[0];
        let imageURL = document.querySelector('#image_input').value;
        if(!validProperties(name, description, imageURL, imageFile)){
            return;
        }
        
        const formData = new FormData();
        formData.append('Name', name);
        formData.append('Description', description);
        formData.append('ImageURL',imageURL);
        formData.append('Image', imageFile);
        debugger;

        fetch(url, {
            method: 'POST',
            body: formData
        }).then(response => {
            if(response.status === 201){
                alert('Created');
                window.location.href = "categories.html";//"http://127.0.0.1:5500/";
            } else {
                response.text()
                .then((error)=>{
                    alert(error);
                });
            }
        });
    }

    async function fetchCategory()
    {
        debugger;
        let productCard = `
            <div id="form-image" style="background: url(https://images.unsplash.com/photo-1598903910670-321f09e94b42?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=375&q=80)">
            </div>
            <div id="post-form">
                <h2>Creation Form</h2>
                <div class="property-wrapper"> 
                    <label for="name_input">Name</label>
                    <input type="text" name="name_input_name" id="name_input" class="create-input">
                </div>

                <div class="property-wrapper"> 
                    <label for="description_input">Description</label>
                    <input type="text" name="name_input_description" id="description_input" class="create-input">
                </div>

                <div class="property-wrapper"> 
                    <label for="image_input">Image URL</label>
                    <input type="text" name="name_input_image" id="image_input" class="create-input">
                </div>

                <div class="property-wrapper">
                    <label for="image_file_input">Image File</label>
                    <input type="file" name="image" id="image_file_input" class="create-input custom-file-input">
                </div>

                <div class="submit-container">
                    <button class="create-submit">Create</button>
                </div>
            </div>
        `;
        document.querySelector('#form-wrapper').innerHTML = productCard;
        
        let createButton = document.querySelector('#post-form .create-submit'); /*.delete-btn[data-delete-product-id]*/ 
        createButton.addEventListener('click', PostFormCategory);
        //createButton.addEventListener('click', createCategory);PostFormCategory
    }

    const baseUrl = 'http://localhost:3030/api';
    fetchCategory();
});