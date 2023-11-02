const BASE_URL = 'http://localhost:3030/jsonstore/tasks';

const courseTypes = [
    'Long',
    'Medium', 
    'Short',
];

const courseListElement = document.getElementById('list');

const loadButtonElement = document.getElementById('load-course'); 
const addSubmitButtonElement = document.getElementById('add-course'); 
const editSubmitButtonElement = document.getElementById('edit-course'); 

const courseTitleElement = document.getElementById('course-name');
const courseTypeElement = document.getElementById('course-type');
const courseDescriptionElement = document.getElementById('description');
const courseTeacherElement = document.getElementById('teacher-name');

let currentCourseId = '';

loadButtonElement.addEventListener('click', loadCourses);
addSubmitButtonElement.addEventListener('click', addCourse);
editSubmitButtonElement.addEventListener('click', editCourse);

async function editCourse(e) {
    e.preventDefault();
    
    const title = courseTitleElement.value;
    const type = courseTypeElement.value;
    const description = courseDescriptionElement.value;
    const teacher = courseTeacherElement.value;

    if (!courseTypes.includes(type)) {
        return;
    }
    
    const course = {
        title,
        type,
        description,
        teacher,
    };

    await fetch(`${BASE_URL}/${currentCourseId}`, {
        method: 'PUT',
        body: JSON.stringify(course),
    });

    clearForm();
    
    addSubmitButtonElement.disabled = false;
    editSubmitButtonElement.disabled = true;

    await loadCourses();
} 

async function addCourse(e) {
    e.preventDefault();
    const title = courseTitleElement.value;
    const type = courseTypeElement.value;
    const description = courseDescriptionElement.value;
    const teacher = courseTeacherElement.value;

    if (!courseTypes.includes(type)) {
        return;
    }

    const course = {
        title,
        type,
        description,
        teacher,
    };

    await fetch(BASE_URL, {
        method: 'POST',
        body: JSON.stringify(course),
    });

    clearForm();

    await loadCourses();
}

function renderCourse(course) {
    const headingElement = document.createElement('h2');
    headingElement.textContent = course.title;

    const teacherElement = document.createElement('h3');
    teacherElement.textContent = course.teacher;

    const typeElement = document.createElement('h3');
    typeElement.textContent = course.type;

    const descriptionElement = document.createElement('h4');
    descriptionElement.textContent = course.description;

    const editButtonElement = document.createElement('button');
    editButtonElement.className = 'edit-btn';
    editButtonElement.textContent = 'Edit Course';

    const finishButtonElement = document.createElement('button');
    finishButtonElement.className = 'finish-btn';
    finishButtonElement.textContent = 'Finish Course';

    const courseContainer = document.createElement('div');
    courseContainer.className = 'container';
    courseContainer.appendChild(headingElement);
    courseContainer.appendChild(teacherElement);
    courseContainer.appendChild(typeElement);
    courseContainer.appendChild(descriptionElement);
    courseContainer.appendChild(editButtonElement);
    courseContainer.appendChild(finishButtonElement);

    editButtonElement.addEventListener('click', (e) => {
        courseTitleElement.value = course.title;
        courseTypeElement.value = course.type;
        courseDescriptionElement.value = course.description;
        courseTeacherElement.value = course.teacher;

        currentCourseId = courseContainer.getAttribute('data-course-id');
        courseContainer.remove();

        addSubmitButtonElement.disabled = true;
        editSubmitButtonElement.disabled = false;
    });

    finishButtonElement.addEventListener('click', async (e) => {
        await fetch(`${BASE_URL}/${course._id}`, {
            method: 'DELETE',
        });

        await loadCourses();
    });

    return courseContainer;
}

async function loadCourses() {
    const response = await fetch(BASE_URL);
    const data = await response.json();

    courseListElement.innerHTML = '';

    const courses = Object.keys(data).map(key => ({_id: key, ...data[key]})); // optional

    for (const course of courses) {
        const courseElement = renderCourse(course);
        courseElement.setAttribute('data-course-id', course._id);
        
        courseListElement.appendChild(courseElement);
    }
}

function clearForm() {
    courseTitleElement.value = '';
    courseTypeElement.value = '';
    courseDescriptionElement.value = '';
    courseTeacherElement.value = '';
}
