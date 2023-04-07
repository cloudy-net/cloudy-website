
// Elements

const hamburger = document.getElementById("hamburger");
const closeMobileMenu = document.getElementById("closeMobileMenu");
const mobileMenuContainer = document.getElementsByClassName("mobileMenuContainer");
const mobileMenu = document.getElementById("mobileMenu");
const philosophyHomePage = document.getElementsByClassName("whyCloudyDiv");


// Toggle mobile nav

var x = getComputedStyle(mobileMenuContainer[0]);

hamburger.addEventListener("click", () => {
    if (x.getPropertyValue("display") === "none") {
        mobileMenuContainer[0].style.display = "block";
        mobileMenu.classList.add("show");
    }
});

closeMobileMenu.addEventListener("click", () => {
    mobileMenuContainer[0].style.display = "none";
    mobileMenu.classList.remove("show");
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

