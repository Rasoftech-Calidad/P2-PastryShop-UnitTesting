window.addEventListener('DOMContentLoaded', function(event){
    const sec = document.querySelector('.sec');
    const toggle = document.querySelector('.sec .toggle-colors');

    toggle.onclick = function(){
        sec.classList.toggle('dark');
    }
});