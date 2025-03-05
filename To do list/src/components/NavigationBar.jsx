import React from "react";
import { Link } from "react-router-dom";

const NavigationBar = () => {
  return (
    <nav>
      <ul>
        <li><Link to="/home">Home</Link></li>
        <li><Link to="/about">About</Link></li>
        <li><Link to="/contact">Contact</Link></li>
        <li><Link to="/services">Services</Link></li>
        <li><Link to="/todo">To-Do List</Link></li>
        <li><Link to="/add-task">Add Task</Link></li>
      </ul>
    </nav>
  );
};

export default NavigationBar;
