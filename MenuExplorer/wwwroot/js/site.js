const searchInput = document.getElementById("menuSearch");
const menuCards = document.querySelectorAll(".menu-card");
const noSearchResults = document.getElementById("noSearchResults");

searchInput.addEventListener("input", () => {
    const searchTerm = searchInput.value.toLowerCase();
    let foundItems = 0;
    menuCards.forEach((card) => {
        const searchableText = card.dataset.menuSearch.toLowerCase();

        if (searchableText.includes(searchTerm)) {
            card.style.display = "";
            foundItems++;
        } else {
            card.style.display = "none";
        }
    })

    if (foundItems == 0) {
        noSearchResults.style.display = "";
    } else {
        noSearchResults.style.display = "none";
    }
})