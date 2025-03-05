import React, { useState, useRef, useEffect } from 'react';
import './ToDoList.css';

function ToDoList() {
    const [tasks, setTasks] = useState([]);
    const [newTask, setNewTask] = useState("");
    const [newNote, setNewNote] = useState("");
    const inputRef = useRef(null); // Reference for input field

    // Load tasks from local storage
    useEffect(() => {
        const storedTasks = JSON.parse(localStorage.getItem('tasks'));
        if (storedTasks) {
            setTasks(storedTasks);
        }
    }, []);

    // Save tasks to local storage
    useEffect(() => {
        localStorage.setItem('tasks', JSON.stringify(tasks));
    }, [tasks]);

    function handleTaskInputChange(event) {
        setNewTask(event.target.value);
    }

    function handleNoteInputChange(event) {
        setNewNote(event.target.value);
    }

    function addTask() {
        if (newTask.trim() !== "" && !tasks.some(task => task.text === newTask.trim())) {
            const newTaskObj = { text: newTask.trim(), completed: false, note: newNote.trim() || "" };
            setTasks([...tasks, newTaskObj]);
            setNewTask("");
            setNewNote("");
            inputRef.current.focus(); // Auto-focus input after adding task
        }
    }

    function handleKeyDown(event) {
        if (event.key === "Enter") {
            addTask();
        }
    }

    function deleteTask(index) {
        setTasks(tasks.filter((_, i) => i !== index));
    }

    function moveTaskUp(index) {
        if (index > 0) {
            const updatedTasks = [...tasks];
            [updatedTasks[index - 1], updatedTasks[index]] = [updatedTasks[index], updatedTasks[index - 1]];
            setTasks(updatedTasks);
        }
    }

    function moveTaskDown(index) {
        if (index < tasks.length - 1) {
            const updatedTasks = [...tasks];
            [updatedTasks[index], updatedTasks[index + 1]] = [updatedTasks[index + 1], updatedTasks[index]];
            setTasks(updatedTasks);
        }
    }

    function toggleCompletion(index) {
        const updatedTasks = tasks.map((task, i) => {
            if (i === index) {
                return { ...task, completed: !task.completed };
            }
            return task;
        });
        setTasks(updatedTasks);
    }

    function clearAllTasks() {
        setTasks([]);
    }

    function editTask(index) {
        const updatedTasks = [...tasks];
        const editedTask = updatedTasks[index];
        setNewTask(editedTask.text);
        setNewNote(editedTask.note);
        deleteTask(index); // Remove the task while editing
    }

    return (
        <div className="to-do-list">
            <h1>To-Do List</h1>
            <div>
                <input
                    type="text"
                    placeholder="Enter a task..."
                    value={newTask}
                    onChange={handleTaskInputChange}
                    onKeyDown={handleKeyDown}
                    ref={inputRef}
                />
                <textarea
                    placeholder="Add a note..."
                    value={newNote}
                    onChange={handleNoteInputChange}
                />
                <button className="add-button" onClick={addTask}>Add</button>
                <button className="clear-button" onClick={clearAllTasks}>Clear All</button>
            </div>
            <ol>
                {tasks.map((task, index) => (
                    <li key={index} className={task.completed ? "completed" : ""}>
                        <span onClick={() => toggleCompletion(index)}>{task.text}</span>
                        {task.note && <p className="task-note">{task.note}</p>}
                        <div className="buttons">
                            <button onClick={() => moveTaskUp(index)}>⬆</button>
                            <button onClick={() => moveTaskDown(index)}>⬇</button>
                            <button onClick={() => deleteTask(index)}>❌</button>
                            <button onClick={() => editTask(index)}>✏️ Edit</button>
                        </div>
                    </li>
                ))}
            </ol>
        </div>
    );
}

export default ToDoList;
