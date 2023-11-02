function attachEvents() {
    const [btnLoadPosts, btnViewPost] = Array.from(document.querySelectorAll('button'));
    const posts = document.querySelector('#posts');
    const postTitle = document.querySelector('#post-title');
    const postBody = document.querySelector('#post-body');

    let postInfo = {};
    const postsApiUrl = 'http://localhost:3030/jsonstore/blog/posts';
    const commentsApiUrl = 'http://localhost:3030/jsonstore/blog/comments';

    function createElementWithValueAndTextContent(tag, value, textContent){
        const e = document.createElement(tag);
        e.value = value;
        e.textContent = textContent;
        return e;
    }

    function findPost(selected){
        for (const key in postInfo) {
            if(selected === postInfo[key].id){
                return postInfo[key];
            }
        }
    }

    btnLoadPosts.addEventListener('click', () => {
        fetch(postsApiUrl).then(x=> x.json()).then(x=>{
            postInfo = x;
            for (const key in x) {
                posts.appendChild(createElementWithValueAndTextContent('option', x[key].id, x[key].title))
            }
        }).catch()
    })

    btnViewPost.addEventListener('click', () => {
        fetch(commentsApiUrl).then(x=>x.json().then(x => {
            let post = findPost(posts.value)
            postTitle.textContent = post.title;
            postBody.textContent = post.body;
            const body = document.querySelector('body');
            const ul = document.querySelector('#post-comments');

            body.removeChild(ul);
            const newUL = document.createElement('ul');
            newUL.setAttribute('id', 'post-comments');
            body.appendChild(newUL);
            const postComents = document.querySelector('#post-comments');

            for (const key in x) {
                if (x[key].postId === posts.value) {
                    const i = document.createElement('li');
                    i.textContent = x[key].text;
                    postComents.appendChild(i);
                }
            }
        })).catch();
    })
}

attachEvents();