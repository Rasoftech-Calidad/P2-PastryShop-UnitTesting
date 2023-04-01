window.addEventListener('DOMContentLoaded', function(event){

    function toggleFunctions(event){
        const container = document.querySelector('#navigation-container .menu-functions');
        container.classList.toggle('func-on');
    }

    let functionBtn = document.querySelector('#navigation-container .func-toggle');
    functionBtn.addEventListener('click', toggleFunctions);
});