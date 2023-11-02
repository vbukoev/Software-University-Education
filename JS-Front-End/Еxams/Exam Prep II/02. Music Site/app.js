window.addEventListener('load', solve);

function solve() {
    let genre = document.getElementById("genre");
    let name = document.getElementById("name");
    let author = document.getElementById("author");
    let date = document.getElementById("date");

    let addButton = document.getElementById("add-btn");
    addButton.addEventListener('click', addFunc);

    let allHitsContainer = document.getElementsByClassName("all-hits-container")[0];
    let likes = document.getElementsByClassName("likes")[0];
    let saved = document.getElementsByClassName("saved-container")[0];

    function addFunc(e) {
        e.preventDefault();
        
        if (!genre.value || !name.value || ! author.value || !date.value) {
            return;
        }

        let div = document.createElement('div');
        div.setAttribute('class', 'hits-info');
        // div.setAttribute('img', './static/img/img.png');

        let img = document.createElement('img');
        img.src = './static/img/img.png' ;
        div.appendChild(img);

        let h2genre = document.createElement('h2');
        h2genre.textContent = `Genre: ${genre.value}`;
        div.appendChild(h2genre);
        
        let h2name = document.createElement('h2');
        h2name.textContent = `Name: ${name.value}`;
        div.appendChild(h2name);

        let h2author = document.createElement('h2');
        h2author.textContent = `Author: ${author.value}`;
        div.appendChild(h2author);

        let h3date = document.createElement('h3');
        h3date.textContent = `Date: ${date.value}`;
        div.appendChild(h3date);

        let saveButton = document.createElement('button');
        saveButton.addEventListener('click', saveFunc);
        saveButton.setAttribute('class', 'save-btn');
        saveButton.textContent = "Save song";
        div.appendChild(saveButton);

        let likeButton = document.createElement('button');
        likeButton.addEventListener('click', likeFunc);
        likeButton.setAttribute('class', 'like-btn');
        likeButton.textContent = "Like song";
        div.appendChild(likeButton);

        
        let deleteButton = document.createElement('button');
        deleteButton.addEventListener('click', deleteFunc);
        deleteButton.setAttribute('class', 'delete-btn');
        deleteButton.textContent = "Delete";
        div.appendChild(deleteButton);

        allHitsContainer.appendChild(div);
        
        genre.value = "";
        name.value = "";
        author.value = "";
        date.value = "";


    }

    function saveFunc(e) {

        let data  = e.target.parentElement;
        let elements = Array.from(data.children);

        let div = document.createElement('div');
        div.setAttribute('class', "hits-info")
        for (let i = 0; i < elements.length; i ++){
            if (i != 5 && i != 6){
                div.appendChild(elements[i]);
            }
        }

        saved.appendChild(div);

        data.remove();

    }

    function likeFunc(e) {
        let p = likes.children[0];
        let [text, count] = p.textContent.split(': ');
        
        p.textContent = `${text}: ${Number(count) + 1}`;

        e.target.setAttribute('disabled', true);


    }

    function deleteFunc(e) {
        let data = e.target.parentElement;

        data.remove();

    }



}