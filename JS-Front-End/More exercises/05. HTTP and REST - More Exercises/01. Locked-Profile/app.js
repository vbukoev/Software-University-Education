async function lockedProfile() {
    const apiUrl = 'http://localhost:3030/jsonstore/advanced/profiles';
    const profile = document.querySelector('.profile');
    const main = document.querySelector('#main');

    const loadDataFromApi = async () => { //function which has been implemented many times before and i copied it (it has been used a lot of time until now)
        const data = await fetch(apiUrl);
        return await data.json();
    }

    const showMoreBtn = () => {
        const e = event.target.parentElement;
        const [lockCheck, unlockCheck] = e.querySelectorAll('input[type="radio"]');
        const showInfo = e.querySelector('.user1Username');
        if (unlockCheck.checked){
            showInfo.style.display = 'inline-block';
            event.target.textContent = 'Hide it';
        }else{
            showInfo.style.display = 'none';
            event.target.textContent = 'Show more';
        }
    }

    const createHtmlElement2 = (data) => {
        const copyElement = profile.cloneNode(true);
        const [name, email, age] = Array.from(copyElement.querySelectorAll('input')).slice(2);
        const showInfo = copyElement.querySelector('.user1Username');
        name.value = data.username;
        email.value = data.email;
        age.value = data.age;
        showInfo.style.display = 'none';
        const showMoreButton = copyElement.querySelector('button');
        showMoreButton.addEventListener('click', showMoreBtn);
        return copyElement;
    } 

    const loadDataToHTML = async (data) => {
        main.innerHTML = '';

        for (const key in data) {
            main.appendChild(await createHtmlElement2(data[key]));
        }
    }
    await loadDataToHTML(await loadDataFromApi());
}