import React, { useState, useRef, useEffect } from 'react';
import './ToDoList.css';

function ToDoList() {
    const [tasks, setTasks] = useState([]);
    const [newTask, setNewTask] = useState("");
    const [newNote, setNewNote] = useState("");
    const [taskTime, setTaskTime] = useState("");
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

    function handleTaskInputChange(event) {
        setNewTask(event.target.value);
    }

    function handleNoteInputChange(event) {
        setNewNote(event.target.value);
    }

    function handleTimeChange(event) {
        setTaskTime(event.target.value);
    }

    function formatDateTime() {
        const now = new Date();
        const options = { weekday: "long", month: "long", day: "numeric", year: "numeric" };
        const date = now.toLocaleDateString(undefined, options);
        
        let hours = now.getHours();
        let minutes = now.getMinutes();
        const ampm = hours >= 12 ? "PM" : "AM";
        hours = hours % 12 || 12; 
        minutes = minutes < 10 ? "0" + minutes : minutes; 
        const time = `${hours}:${minutes} ${ampm}`;

        return `${date} at ${time}`;
    }

    function convertTo12HourFormat(time24) {
        if (!time24) return "No Deadline";
        let [hours, minutes] = time24.split(":");
        let ampm = "AM";
        hours = parseInt(hours, 10);
        if (hours >= 12) {
            ampm = "PM";
            if (hours > 12) hours -= 12;
        } else if (hours === 0) {
            hours = 12;
        }
        return `${hours}:${minutes} ${ampm}`;
    }

    function addTask() {
        if (newTask.trim() !== "" && !tasks.some(task => task.text === newTask.trim())) {
            const newTaskObj = {
                text: newTask.trim(),
                note: newNote.trim() || "",
                completed: false,
                time: convertTo12HourFormat(taskTime),
                dateAdded: formatDateTime()
            };
            setTasks([...tasks, newTaskObj]);
            setNewTask("");
            setNewNote("");
            setTaskTime("");
            inputRef.current.focus();
        }
    }

    function deleteTask(index) {
        setTasks(tasks.filter((_, i) => i !== index));
    }

    function toggleCompletion(index) {
        const updatedTasks = tasks.map((task, i) => 
            i === index ? { ...task, completed: !task.completed } : task
        );
        setTasks(updatedTasks);
    }

    function editTask(index) {
        const editedTask = tasks[index];
        setNewTask(editedTask.text);
        setNewNote(editedTask.note);
        setTaskTime(editedTask.time);
        deleteTask(index);
    }

    return (
        <div className="to-do-list">
            <h1>To-Do List</h1>
            <div className="input-container">
                <input
                    type="text"
                    placeholder="Enter a task..."
                    value={newTask}
                    onChange={handleTaskInputChange}
                    ref={inputRef}
                />
                <textarea
                    placeholder="Add a note..."
                    value={newNote}
                    onChange={handleNoteInputChange}
                />
                <input
                    type="time"
                    value={taskTime}
                    onChange={handleTimeChange}
                />
                <button className="add-button" onClick={addTask}>Add Task</button>
            </div>
            <ol>
                {tasks.map((task, index) => (
                    <li key={index} className={task.completed ? "completed" : ""}>
                        <div className="task-content">
                            <span onClick={() => toggleCompletion(index)}>{task.text}</span>
                            {task.note && <p className="task-note">{task.note}</p>}
                            <p className="task-time">⏰ {task.time}</p>
                            <p className="task-date">📅 {task.dateAdded}</p>
                        </div>
                        <div className="buttons">
                            <button onClick={() => toggleCompletion(index)}>
                                {task.completed ? "Undo" : "✔ Done"}
                            </button>
                            <button onClick={() => editTask(index)}>✏ Edit</button>
                            <button onClick={() => deleteTask(index)}>❌ Delete</button>
                        </div>
                    </li>
                ))}
            </ol>
        </div>
    );
}

export default ToDoList;
