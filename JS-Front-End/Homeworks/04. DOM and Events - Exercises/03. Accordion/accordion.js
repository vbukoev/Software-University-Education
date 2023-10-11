function toggle() {
    const extra = document.querySelector("#extra");
    const btn = document.querySelector(".button");

    if(extra.style.display === "none"){
        extra.style.display = "block";
        btn.textContent = "Less";
    }else{
        extra.style.display = "none";
        btn.textContent = "More";
    }
}