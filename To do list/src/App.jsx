import React, { useState } from "react";
import NavigationBar from "./components/NavigationBar";  // Navigation Bar Component
import { Routes, Route } from "react-router-dom";
import HomePage from "./components/HomePage";            // Home Page with To-Do List
import AboutPage from "./components/AboutPage";          // About Page
import ContactPage from "./components/ContactPage";      // Contact Page
import ServicesPage from "./components/ServicesPage";    // Services Page
import TodoList from "./components/TodoList";            // To-Do List Page
import AddTask from "./components/AddTask";              // Add Task Form

const App = () => {
  const [tasks, setTasks] = useState([]);

  const addTask = (taskText) => {
    setTasks([...tasks, { text: taskText, completed: false }]);
  };

  const toggleTask = (index) => {
    const updatedTasks = [...tasks];
    updatedTasks[index].completed = !updatedTasks[index].completed;
    setTasks(updatedTasks);
  };

  const deleteTask = (index) => {
    const updatedTasks = tasks.filter((_, i) => i !== index);
    setTasks(updatedTasks);
  };

  return (
    <div className="App">
      <NavigationBar />
      <Routes>
        <Route path="/home" element={<HomePage />} />
        <Route path="/about" element={<AboutPage />} />
        <Route path="/contact" element={<ContactPage />} />
        <Route path="/services" element={<ServicesPage />} />
        <Route path="/todo" element={<TodoList tasks={tasks} toggleTask={toggleTask} deleteTask={deleteTask} />} />
        <Route path="/add-task" element={<AddTask addTask={addTask} />} />
      </Routes>
    </div>
  );
};

export default App;
