import {Routes, Route, useLocation} from 'react-router-dom';

import NotFound from './Pages/Common/NotFound';
import Posts from './Pages/Posts';
import SinglePost from './Pages/Posts/SinglePost';
import AddPost from './Pages/Posts/AddPost';
import User from './Pages/Users/User';
import Login from './Pages/Login';

function Router({setAuth}) {
  const location = useLocation();
  return (
    <Routes location={location} key={location.pathname}>
      <Route path="/" element={<Posts />} />
      <Route path="Posts/:id" element={<SinglePost />} />
      <Route path="Posts/Add" element={<AddPost />} />
      <Route path="Users/:id" element={<User />} />
      <Route path="Login" element={<Login setAuth={setAuth} />} />
      <Route path="*" element={<NotFound />} />
    </Routes>
  );
}

export default Router;
