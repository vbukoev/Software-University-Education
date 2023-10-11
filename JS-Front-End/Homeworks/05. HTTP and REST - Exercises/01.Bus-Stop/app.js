function getInfo() {
    const stopIdInput = document.getElementById('stopId');
    const stopNameContainer = document.getElementById('stopName');
    const busesContainer = document.getElementById('buses');
    const stopId = stopIdInput.value;
    const BASE_URL = 'http://localhost:3030/jsonstore/bus/businfo/';

    stopNameContainer.textContent = '';
    busesContainer.innerHTML = '';
    fetch(`${BASE_URL}${stopId}`)
        .then((res) => res.json())
        .then((busInfo) => {
            const { name, buses } = busInfo;
            stopNameContainer.textContent = name;
            for (const busId in buses) {
                const li = document.createElement('li');
                li.textContent = `Bus ${busId} arrives in ${buses[busId]} minutes`;
                busesContainer.appendChild(li);
            }
        })
        .catch(() =>{
            stopNameContainer.textContent = 'Error';
        });
}