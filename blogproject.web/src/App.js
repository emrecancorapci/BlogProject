import { Routes, Route } from "react-router-dom";
import './App.css';

import Home from './components/Home';
import About from './components/About';
import Posts from "./components/Posts";
import PostDetailed from "./components/Posts/PostDetailed";
import AddPost from "./components/Posts/AddPost";
import User from "./components/Users/User";

function App() {
  return (
    <div className="App">
    <h1>Yet Another Blog Project!</h1>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="about" element={<About />} />
        <Route path="Posts" element={<Posts />} />
        <Route path="Post" element={<PostDetailed />} />
        <Route path="User" element={<User />} />
        <Route path="Posts/Add" element={<AddPost />} />
      </Routes>
    </div>
  );
}

export default App;
