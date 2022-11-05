import React, {useState, useEffect} from 'react';
import {Routes, Route} from 'react-router-dom';
import {getToken} from './Functions/User';
import './App.css';

import NotFound from './Pages/Common/NotFound';

import Posts from './Pages/Posts';
import SinglePost from './Pages/Posts/SinglePost';
import AddPost from './Pages/Posts/AddPost';
import User from './Pages/Users/User';
import Login from './Pages/Login';

import Navigation from './Components/Common/Navigation';
import SidePanel from './Components/Common/SidePanel';


function App() {
  const title = 'Yet Another Blog Project';

  const [auth, setAuth] = useState(false);

  useEffect(() => {
    const user = getToken();
    user ? setAuth(true) : 1;
  }, [auth]);

  // Add tabs to home page
  // Posts / My Posts / New Post

  return (<>
    <header>
      <div className='row'>
        <Navigation title={title} auth={auth} setAuth={setAuth}/>
      </div>
    </header>

    <div className='container' style={{padding: '1rem 0rem'}}>
      <div className='row justify-content-evenly'>
        <div className='col-lg-7 col-sm-12 order-lg-1 order-sm-3 px-3'>
          <main>
            <Routes>
              <Route path="/" element={<Posts />} />
              <Route path="Posts/:id" element={<SinglePost />} />
              <Route path="Posts/Add" element={<AddPost />} />
              <Route path="Users/:id" element={<User />} />
              <Route path="Login" element={<Login setAuth={setAuth} />} />
              <Route path="*" element={<NotFound />} />
            </Routes>
          </main>
        </div>
        <div className='col-lg-3 col-sm-12 order-2 p-3'>
          <SidePanel/>
        </div>
      </div>
    </div>
    <footer></footer>
  </>);
}

export default App;
