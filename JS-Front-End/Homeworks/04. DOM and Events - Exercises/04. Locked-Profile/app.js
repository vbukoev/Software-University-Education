function lockedProfile() {
    const buttons = Array.from(document.getElementsByTagName('button'));
    buttons 
        .forEach((button) => { 
            button.addEventListener('click', toggleInformation);
        });

    function toggleInformation(e){
        const btn = e.target;
        const profile = btn.parentNode;
        const additionalInformationDiv = profile.querySelector('div[id^="user"][id$="HiddenFields"]');
        const lockStatus = profile.querySelector('input[value="unlock"]');

        if(lockStatus.checked){
            if(btn.textContent === 'Show more'){
                additionalInformationDiv.style.display = 'inline-block';
                btn.textContent = 'Hide it';
            } else if(btn.textContent === 'Hide it'){
                additionalInformationDiv.style.display = 'none';
                btn.textContent = 'Show more';
            }
        }        
    }
}