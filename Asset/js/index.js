let flag = 0;

function controller(x) {

    flag = flag + x;
    slideShow(flag);
    console.log(flag);
}

slideShow(flag);

function slideShow(num) {

    let totalSlides = document.querySelectorAll(" .slides");
    console.log(totalSlides);

    if (num == totalSlides.length) {
        num = 0;
        flag = 0;
    }
    if (num < 0) {
        num = totalSlides.length - 1;
        flag = totalSlides.length - 1;
    }



    for (let i = 0; i < totalSlides.length; i++) {
        totalSlides[i].style.display = "none";
    }
    totalSlides[num].style.display = "block";
}