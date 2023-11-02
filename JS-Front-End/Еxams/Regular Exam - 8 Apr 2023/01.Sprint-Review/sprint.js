function solve(input){
    const ticketsLines = Number(input.shift());
    const tickets = input.slice(0, ticketsLines);
    const cmds = input.slice(ticketsLines);

    const board = tickets.reduce((acc, curr) => {
        const [ assignee, taskId, title, status, points ] = curr.split(':');

        if(!acc.hasOwnProperty(assignee)){
            acc[assignee] = [];
        }

        acc[assignee].push({ taskId, title, status, points: Number(points) });

        return acc;
    }, {});

    const commandRunner = {
        'Add New': addNewTask,
        'Change Status':changeTaskStatus,
        'Remove Task': removeTask
    }

    cmds.forEach((command) => {
        const [ commandName, ...rest ] = command.split(':');
        commandRunner[commandName](...rest);
    });

    const todoTaskPoints = calculateTotalForStatus('ToDo');
    const inProgresskPoints = calculateTotalForStatus('In Progress');
    const codeReviewPoints = calculateTotalForStatus('Code Review');
    const donePoints = calculateTotalForStatus('Done');

    console.log(`ToDo: ${todoTaskPoints}pts`);
    console.log(`In Progress: ${inProgresskPoints}pts`);
    console.log(`Code Review: ${codeReviewPoints}pts`);
    console.log(`Done Points: ${donePoints}pts`);

    if(donePoints >= todoTaskPoints + inProgresskPoints + codeReviewPoints){
        console.log('Sprint was successful!');
    }else{
        console.log('Sprint was unsuccessful...')
    }

    function addNewTask(assignee, taskId, title, status, points){
        if(!board.hasOwnProperty(assignee)){
            console.log(`Assignee ${assignee} does not exist on the board!`);
            return;
        }

        board[assignee].push( {taskId, title, status, points: Number(points)} );
    }

    function changeTaskStatus(assignee, taskId, status){
        if(!board.hasOwnProperty(assignee)){
            console.log(`Assignee ${assignee} does not exist on the board!`);
            return;
        }

        const task = board[assignee].find((t) => t.taskId === taskId);

        if(!task){
            console.log(`Task with ID ${taskId} does not exist for ${assignee}!`);
            return;
        }

        task.status = status;
    }

    function removeTask(assignee, index){
        if(!board.hasOwnProperty(assignee)){
            console.log(`Assignee ${assignee} does not exist on the board!`);
            return;
        }

        if(index < 0 || index >= board[assignee].length){
            console.log('Index is out of range!');
            return;
        }

        board[assignee].splice(index, 1);
    }

    function calculateTotalForStatus(status){
       return Object.values(board).reduce((acc, curr) => {
            const boardTotal = curr.filter(t => t.status === status)
            .reduce((tasksTotal, task) => tasksTotal + task.points, 0);
    
        return acc + boardTotal;
        }, 0)
    }
}

//solve([
//    '5',
//    'Kiril:BOP-1209:Fix Minor Bug:ToDo:3',
//    'Mariya:BOP-1210:Fix Major Bug:In Progress:3',
//    'Peter:BOP-1211:POC:Code Review:5',
//    'Georgi:BOP-1212:Investigation Task:Done:2',
//    'Mariya:BOP-1213:New Account Page:In Progress:13',
//    'Add New:Kiril:BOP-1217:Add Info Page:In Progress:5',
//    'Change Status:Peter:BOP-1290:ToDo',
//    'Remove Task:Mariya:1',
//    'Remove Task:Joro:1',
//    ])