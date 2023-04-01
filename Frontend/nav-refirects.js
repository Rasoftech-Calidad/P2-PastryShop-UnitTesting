window.addEventListener('DOMContentLoaded', function(event){
    function goToCombos(){
        window.location.href = "../Combos/combos.html";
    }

    function goToCategories(){
        window.location.href = "../Categories/categories.html";
    }
    //debugger
    let combosBtn = document.querySelector('#navigation-container #go2combos');
    if(combosBtn){
        combosBtn.addEventListener('click', goToCombos);
    }

    let categoriesBtn = document.querySelector('#navigation-container #go2categories');
    if(categoriesBtn){
        categoriesBtn.addEventListener('click', goToCategories);
    }
});