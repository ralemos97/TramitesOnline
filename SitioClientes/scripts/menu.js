var menu = (function () {
    function changeStyleOptionMenu(id, isHover) {
        if (!id)
            return;

        let elementImage = document.getElementById(id);
        if (isHover) {
            document.getElementById(id + 'White').classList.remove('hidden');
            elementImage.classList.add('hidden');
        } else {
            document.getElementById(id + 'White').classList.add('hidden');
            elementImage.classList.remove('hidden');
        }
    }

    function showMenu(e) {
        var getMenuProfile = document.getElementById('menuProfile');

        getMenuProfile.style.display = getMenuProfile.style.display === 'block' ? 'none' : 'block';
    }
    
    return { changeStyleOptionMenu, showMenuProfile: showMenu };
})();