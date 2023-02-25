
// Elements

const hamburger = document.getElementById("hamburger");
const smallMenu = document.getElementsByClassName("menuSmall");
const dropdownHamburger = document.getElementById("dropdownHamburger");
const closeMenuSmall = document.getElementById("closeMenuSmall");
const philosophyHomePage = document.getElementsByClassName("whyCloudyDiv");


// Toggle mobile nav

var x = getComputedStyle(dropdownHamburger);

hamburger.addEventListener("click", () => {
    if (x.getPropertyValue("display") === "none") {
        dropdownHamburger.style.display = "block";
    } else {
        dropdownHamburger.style.display = "none";
    }
});

closeMenuSmall.addEventListener("click", () => {
    dropdownHamburger.style.display = "none";
});

var y = getComputedStyle(smallMenu[1]);

window.addEventListener("resize", () => {
    if (y.getPropertyValue("visibility") === "hidden") {
        dropdownHamburger.style.display = "none";
    }
});


// Scroll animation

function appear() {
    for (let i = 0; i < philosophyHomePage.length; i++) {
        var elDistanceToTop = window.pageYOffset + philosophyHomePage[i].getBoundingClientRect().top
        if (elDistanceToTop < (window.scrollY + window.innerHeight)) {
            philosophyHomePage[i].style.opacity = "1";
        } else {
            philosophyHomePage[i].style.opacity = "0";
        };
    };
};

document.addEventListener("scroll", () => {
    appear();
});


// Display alert for buy buttons

function showAlert() {
    alert("Just want to try out Cloudy or building a non-commercial project? Feel free to download the NuGet packages and get going. Need support or want to talk? Reach out to hello@cloudy.net or +46 76 06 66 920");
};

