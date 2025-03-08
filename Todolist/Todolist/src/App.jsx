import React, { useState } from 'react';
import './App.css';  // Assuming you have a separate stylesheet for global styling
import LoginPage from './loginpage';  // Login page component
import ToDoList from './ToDoList';    // ToDo List page component

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  return (
    <div className="App">
      {isLoggedIn ? (
        <ToDoList />  // Show the to-do list if logged in
      ) : (
        <LoginPage onLogin={setIsLoggedIn} />  // Show login page if not logged in
      )}
    </div>
  );
}

export default App;
