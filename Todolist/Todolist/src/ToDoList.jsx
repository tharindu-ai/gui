import React, { useState, useRef, useEffect } from 'react';
import './ToDoList.css';  // Import To-Do list specific styles

function ToDoList() {
    const [tasks, setTasks] = useState([]);
    const [newTask, setNewTask] = useState('');
    const [newNote, setNewNote] = useState('');
    const [taskTime, setTaskTime] = useState('');
    const inputRef = useRef(null);

    useEffect(() => {
        const storedTasks = JSON.parse(localStorage.getItem('tasks'));
        if (storedTasks) {
            setTasks(storedTasks);
        }
    }, []);

    useEffect(() => {
        localStorage.setItem('tasks', JSON.stringify(tasks));
    }, [tasks]);

    function addTask() {
        if (newTask.trim() !== '') {
            const newTaskObj = {
                text: newTask.trim(),
                note: newNote.trim() || '',
                completed: false,
                time: taskTime || 'No Deadline',
            };
            setTasks([...tasks, newTaskObj]);
            setNewTask('');
            setNewNote('');
            setTaskTime('');
            inputRef.current.focus();
        }
    }

    // Sort tasks by time
    const sortTasksByTime = () => {
        const sortedTasks = [...tasks].sort((a, b) => {
            if (a.time === 'No Deadline' && b.time !== 'No Deadline') return 1;
            if (a.time !== 'No Deadline' && b.time === 'No Deadline') return -1;
            return a.time.localeCompare(b.time);
        });
        setTasks(sortedTasks);
    };

    return (
        <div className="to-do-list">
            <h1>To-Do List</h1>
            <div className="input-container">
                <input
                    type="text"
                    placeholder="Enter a task..."
                    value={newTask}
                    onChange={(e) => setNewTask(e.target.value)}
                    ref={inputRef}
                />
                <textarea
                    placeholder="Add a note..."
                    value={newNote}
                    onChange={(e) => setNewNote(e.target.value)}
                />
                <input
                    type="time"
                    value={taskTime}
                    onChange={(e) => setTaskTime(e.target.value)}
                />
                <button className="add-button" onClick={addTask}>Add Task</button>
            </div>
            <button className="sort-button" onClick={sortTasksByTime}>Sort by Time</button>
            <ol>
                {tasks.map((task, index) => (
                    <li key={index} className={task.completed ? 'completed' : ''}>
                        <div className="task-content">
                            <span>{task.text}</span>
                            {task.note && <p className="task-note">{task.note}</p>}
                            <p className="task-time">⏰ {task.time}</p>
                        </div>
                    </li>
                ))}
            </ol>
        </div>
    );
}

export default ToDoList;
