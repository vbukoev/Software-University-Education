// const tasksSections = {
//     'ToDo': document.querySelector('#todo-section'),
//     'In Progress': document.querySelector('#in-progress-section'),
//     'Code Review': document.querySelector('#code-review-section'),
//     'Done': document.querySelector('#done-section'),
// }

// const statusToNextStatusMap = {
//     ToDo: 'In Progress',
//     'In Progress': 'Code Review',
//     'Code Review': 'Done',
//     Done: 'Close',
// }

// const inputs = {
//     title: document.querySelector('#title'),
//     description: document.querySelector('#description')
// }

// const BASE_URL = 'http://localhost:3030/jsonstore/tasks/';
// let tasks = {};

// function attachEvents() {
//     document.querySelector('#load-board-btn').addEventListener('click', loadTasks);
//     document.querySelector('#create-task-btn').addEventListener('click', createTask);
// }

// async function loadTasks(){   
//     tasks = await (await fetch(BASE_URL)).json();
    
//     Object.values(tasksSections).forEach(section => (section.innerHTML = ''));

//     Object.values(tasks).forEach((task) => {
//         const section = tasksSections[task.status];
//         const item = createElement('li', null, ['task'], null, section);
//         createElement('h3', task.title, [], null, item);
//         createElement('p', task.description, [], null, item);
//         const button =  createElement('button', 
//         statusToNextStatusMap[task.status] === 'Close' ? 'Close' : 
//         `Move to ${statusToNextStatusMap[task.status]}`, 
//         [], task._id, item);
//         button.addEventListener('click', moveTask);
//     });
// }

// async function createTask(){
//     if(Object.values(inputs).some((input) => input.value === '')){
//         return;
//     }

//     const task = {
//         title: inputs.title.value,
//         description: inputs.description.value,
//         status: 'ToDo',
//     }

//     fetch(BASE_URL,{
//         method: 'POST',
//         body: JSON.stringify(task),
//     }).then(()=>{
//         loadTasks();

//         inputs.title.value = '';
//         inputs.description.value = '';
//     });

// }

// async function moveTask(e){
//     const task = tasks[e.currentTarget.getAttribute('id')];
//     let method = 'PATCH';
//     let body = JSON.stringify({
//         ...task,
//         status: statusToNextStatusMap[task.status], 
//     });

//     if(task.status === 'Done'){
//         method = 'DELETE';
//         body = undefined;
//     }

//     await fetch(`${BASE_URL}/${task._id}`, {
//         method,
//         body, 
//     }); 

//     loadTasks();
// }

// function createElement(type, textContent, classes, id, parent){
//     const element = document.createElement(type);

//     if(textContent){
//         element.textContent = textContent;
//     }

//     if(classes && classes.length > 0){
//         element.classList.add(...classes);
//     }

//     if(id){
//         element.setAttribute('id', id);
//     }

//     if(parent){
//         parent.appendChild(element);
//     }

//     return element;
// }    

// attachEvents();


function attachEvents() {
    const loadBtn = document.getElementById("load-board-btn");
    const BASE_URL = "http://localhost:3030/jsonstore/tasks/";
    const taskTypeToDo = document.querySelector("#todo-section");
    const taskTypeInProgress = document.querySelector("#in-progress-section");
    const taskTypeCodeReview = document.querySelector("#code-review-section");
    const taskTypeDone = document.querySelector("#done-section");
    [toDoUl, inProgressUl, codeReviewUl, doneUl] = document.getElementsByClassName("task-list"); // get the element by the class name from the ->|task list class|<-
    const addTaskBtn = document.getElementById("create-task-btn");
    const titleInput = document.getElementById("title");
    const descriptionInput = document.getElementById("description");
  
    loadBtn.addEventListener("click", getAllTasksHandler);
  
    addTaskBtn.addEventListener("click", addTaskHandler);
  
    function getAllTasksHandler(e) {
      e?.preventDefault();      
      fetch(BASE_URL)
        .then((res) => res.json())
        .then((data) => {
          toDoUl.innerHTML = "";
          inProgressUl.innerHTML = "";
          codeReviewUl.innerHTML = "";
          doneUl.innerHTML = "";
  
          for (let key in data) {
            ({ title, description, status, _id } = data[key]);
            if(status === 'ToDo') {
              toDoUl.classList = 'task-list';
              taskTypeToDo.appendChild(toDoUl);
              const li = createElement('li', '', toDoUl, _id, ['task']); //creating the li element
              createElement('h3', `${title}`, li); //creating the h3 element
              createElement('p', `${description}`, li); //creating the p element
              let moveToInPBtn = createElement('button', 'Move to In Progress', li); //creating the button 
              
              moveToInPBtn.addEventListener('click', moveToInProgressHandler); //attach the event to the button
  
            } else if(status === 'In Progress') {
              inProgressUl.classList = 'task-list';
              taskTypeInProgress.appendChild(inProgressUl);
              const li = createElement('li', '', inProgressUl, _id, ['task']);
              createElement('h3', `${title}`, li);
              createElement('p', `${description}`, li);
              let moveToCodeReviewBtn = createElement('button', 'Move to Code Review', li);
  
              moveToCodeReviewBtn.addEventListener('click', moveToCodeReview);
  
            } else if(status === 'Code Review') {
              codeReviewUl.classList = 'task-list';
              taskTypeCodeReview.appendChild(codeReviewUl);
              const li = createElement('li', '', codeReviewUl, _id, ['task']);
              createElement('h3', `${title}`, li);
              createElement('p', `${description}`, li);
              let moveToDoneBtn = createElement('button', 'Move to Done', li);
  
              moveToDoneBtn.addEventListener('click', moveToDoneHandler);
  
            } else if(status === 'Done') {
              doneUl.classList = 'task-list';
              taskTypeDone.appendChild(doneUl);
              const li = createElement('li', '', doneUl, _id, ['task']);
              createElement('h3', `${title}`, li);
              createElement('p', `${description}`, li);
              let closeBtn = createElement('button', 'Close', li);
  
              closeBtn.addEventListener('click', closeTaskHandler);
            }
          }
        })
        .catch((err) => {
          console.error(err);
        }); // catches an error if there is one or more :) (i hope there are no errors :))))
    }
  
    function moveToInProgressHandler(e) {
      const targetId = e.currentTarget.parentNode.id; //get the parent node of the curr target, it can be done with "this." operator also
      const status = 'In Progress';
      const httpHeaders = {
        method: 'PATCH',
        body: JSON.stringify({ status })
      }
  
      fetch(BASE_URL + targetId, httpHeaders)
      .then(() => getAllTasksHandler())
      .catch((err) => {
        console.error(err);
      })
    }
  
    function moveToCodeReview(e) {
      const target = e.currentTarget.parentNode.id;
      const status = 'Code Review';
      const httpHeaders = {
        method: 'PATCH',
        body: JSON.stringify({ status })
      }
  
      fetch(BASE_URL + target, httpHeaders)
      .then(() => getAllTasksHandler())
      .catch((err) => {
        console.error(err);
      })
    }
  
    function moveToDoneHandler(e) {
      const targetId = e.currentTarget.parentNode.id;
      const status = 'Done';
      const httpHeaders = {
        method: 'PATCH',
        body: JSON.stringify({ status })
      }
  
      fetch(BASE_URL + targetId, httpHeaders)
      .then(() => getAllTasksHandler())
      .catch((err) => {
        console.error(err);
      })
    }
  
    function closeTaskHandler(e) {
      const targetId = e.currentTarget.parentNode.id;
      const httpHeaders = {
        method: 'DELETE'
      }
      fetch(BASE_URL + targetId, httpHeaders)
      .then(() => getAllTasksHandler())
      .catch((err) => {
        console.error(err);
      })
    }
  
    function addTaskHandler(e) {
      e.preventDefault();
      const title = titleInput.value;
      const description = descriptionInput.value;
      const status = "ToDo";
      const httpHeaders = {
        method: "POST",
        body: JSON.stringify({ title, description, status }),
      };
  
      fetch(BASE_URL, httpHeaders)
        .then(() => {
          getAllTasksHandler();
          titleInput.value = '';
          descriptionInput.value = '';
        })
        .catch((err) => {
          console.error(err);
        });
    }
  
    function createElement(type, content, parentNode, id, classes, attributes) {
      const htmlElement = document.createElement(type);
  
      if (content && type !== "input" && type !== "textarea") {
        htmlElement.textContent = content;
      }
  
      if (content && (type === "input" || type === "textarea")) {
        htmlElement.value = content;
      }
  
      if (parentNode) {
        parentNode.appendChild(htmlElement);
      }
  
      if (id) {
        htmlElement.id = id;
      }
  
      if (classes) {
        htmlElement.classList.add(...classes);
      }
  
      if (attributes) {
        for (const key in attributes) {
          htmlElement.setAttribute(key, attributes[key]);
        }
      }
  
      return htmlElement;
    }
  }
  
  attachEvents();