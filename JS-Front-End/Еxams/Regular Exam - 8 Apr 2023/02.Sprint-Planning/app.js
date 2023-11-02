window.addEventListener('load', solve);

function solve() {

    const tasks = {};

    const inputDOMSelectors = {
        title: document.querySelector('#title'),
        description: document.querySelector('#description'),
        label: document.querySelector('#label'),
        points: document.querySelector('#points'),
        assignee: document.querySelector('#assignee'),
    };

    const otherDOMSelectors = {
        hiddenTaskId: document.querySelector('#task-id'),
        createButton: document.querySelector('#create-task-btn'),
        deleteButton: document.querySelector('#delete-task-btn'),
        tasksSection: document.querySelector('#tasks-section'),
        totalPoints: document.querySelector('#total-sprint-points'),
    };

    const icons = {
        'Feature': '&#8865;',
        'Low Priority Bug': '&#9737;',
        'High Priority Bug': '&#9888;'
    }

    const labelClasses = {
        'Feature': 'feature',
        'Low Priority Bug': 'low-priority',
        'High Priority Bug': 'high-priority'
    }
    
    otherDOMSelectors.createButton.addEventListener('click', createTask);
    otherDOMSelectors.deleteButton.addEventListener('click', deleteTask);


    function createTask(e){
        if(Object.values(inputDOMSelectors).some((selector) => selector.value === '')){
            return;
        }    

        const task = {
            id: `task-${Object.values(tasks).length + 1}`,
            title: inputDOMSelectors.title.value,
            description: inputDOMSelectors.description.value,
            label: inputDOMSelectors.label.value,
            points: Number(inputDOMSelectors.points.value),
            assignee: inputDOMSelectors.assignee.value
        }
    
        tasks[task.id] = task; //saves the task
    
        const article = createElement('article', null, ['task-card'], task.id);
        createElement('div', `${task.label} ${icons[task.label]}`, ['task-card-label', labelClasses[task.label]], null, article, true);
        createElement('h3', task.title, ['task-card-title'], null, article);
        createElement('p', task.description, ['task-card-description'], null, article);
        createElement('div', `Estimated at ${task.points} pts`, ['task-card-points'], null, article);
        createElement('div', `Assigned to: ${task.assignee}`, ['task-card-assignee'], null, article);
        
        const tasksActions = createElement('div', null, ['task-card-actions'], null, article);
        const button = createElement('button', 'Delete', [], null, tasksActions);
        button.addEventListener('click', loadDeleteConfirm);
        otherDOMSelectors.tasksSection.appendChild(article);

        calculateTotalPoints(); //function for calculation the total points

        Object.values(inputDOMSelectors).forEach((selector) => (selector.value = ''));
    }

    function loadDeleteConfirm(e){
        const taskId = e.currentTarget.parentElement.parentElement.getAttribute('id');
        
        Object.keys(inputDOMSelectors).forEach((key) => {
            const selector = inputDOMSelectors[key];
            selector.value = tasks[taskId][key];
            selector.setAttribute('disabled', true);
        });

        //looped them with the foreach -> if you want to remove use the code writted below just comment the "object.keys" <- 

        //inputDOMSelectors.title.value = tasks[taskId].title;
        //inputDOMSelectors.description.value = tasks[taskId].description;
        //inputDOMSelectors.label.value = tasks[taskId].label;
        //inputDOMSelectors.points.value = tasks[taskId].points;
        //inputDOMSelectors.assignee.value = tasks[taskId].assignee;
        
        otherDOMSelectors.hiddenTaskId.value = taskId;
        otherDOMSelectors.createButton.setAttribute('disabled', true);
        otherDOMSelectors.deleteButton.removeAttribute('disabled');
        
    }

    function deleteTask(){
        const taskId = otherDOMSelectors.hiddenTaskId.value;
        const taskElement = document.querySelector(`#${taskId}`);
        taskElement.remove();
        delete tasks[taskId];

        Object.values(inputDOMSelectors).forEach((selector) => {            
            selector.value = '';
            selector.removeAttribute('disabled');
        })

        otherDOMSelectors.createButton.removeAttribute('disabled');
        otherDOMSelectors.deleteButton.setAttribute('disabled', true);
        calculateTotalPoints();
    }

    function calculateTotalPoints(){      
        const totalPoints = Object.values(tasks).reduce((acc, curr) => acc + curr.points, 0);
        otherDOMSelectors.totalPoints.textContent = `Total Points ${totalPoints}pts`;
    }

    function createElement(type, textContent, classes, id, parent, useInnerHTML){
        const element = document.createElement(type);

        if(useInnerHTML && textContent){
            element.innerHTML = textContent;
        }else if(textContent){
            element.textContent = textContent;
        }

        if(classes && classes.length > 0){
            element.classList.add(...classes);
        }

        if(id){
            element.setAttribute('id', id);
        }

        if(parent){
            parent.appendChild(element);
        }

        return element;
    }    
}
