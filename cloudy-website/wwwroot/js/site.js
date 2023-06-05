
// Elements

const hamburger = document.getElementById("hamburger");
const closeMobileMenu = document.getElementById("closeMobileMenu");
const mobileMenuContainer = document.getElementsByClassName("mobileMenuContainer");
const mobileMenu = document.getElementById("mobileMenu");
const cycler = document.getElementById("cycler");


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


// Cycler animation

document.addEventListener('DOMContentLoaded', function (event) {
    // array with texts to type in typewriter
    var dataText = ["back offices", "CRUD apps", "admin areas", "back offices"];

    // type one text in the typewriter
    // keeps calling itself until the text is finished
    function typeWriter(text, i, fnCallback) {
        // chekc if text isn't finished yet
        if (i < (text.length)) {
            // add next character to h1
            cycler.innerHTML = text.substring(0, i + 1) + '<span aria-hidden="true"></span>';

            // wait for a while and call this function again for next character
            setTimeout(function () {
                typeWriter(text, i + 1, fnCallback)
            }, 100);
        }
        // text finished, call callback if there is a callback function
        else if (typeof fnCallback == 'function') {
            // call callback after timeout
            setTimeout(fnCallback, 700);
        }
    }
    // start a typewriter animation for a text in the dataText array
    function StartTextAnimation(i) {
        if (typeof dataText[i] == 'undefined') {
            setTimeout(function () {
                StartTextAnimation(0);
            }, 20000);
        }
        // check if dataText[i] exists
        if (dataText[i]) {
            // text exists! start typewriter animation
            typeWriter(dataText[i], 0, function () {
                // after callback (and whole text has been animated), start next text
                StartTextAnimation(i + 1);
            });
        }
    }
    // start the text animation
    StartTextAnimation(0);
});


// Display alert for buy buttons

function showAlert() {
    alert("Just want to try out Cloudy or building a non-commercial project? Feel free to download the NuGet packages and get going. Need support or want to talk? Reach out to hello@cloudy.net or +46 76 06 66 920");
};

