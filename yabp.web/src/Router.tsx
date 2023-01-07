import { Routes, Route, useLocation } from 'react-router-dom';

import NotFound from './Pages/Common/NotFound';
import { AllPosts, ViewPost, AddPost } from './Pages/Posts';
import { ViewUser } from './Pages/Users';
import Login from './Pages/Login';

/**
 * @description Router components
 *
 * @return {JSX.Element} Router component
 */

function Router (): JSX.Element {
  const location = useLocation();
  return (
    <Routes location={location} key={location.pathname}>
      <Route path="/" element={<AllPosts />} />
      <Route path="Post/:id" element={<ViewPost />} />
      <Route path="Post/Add" element={<AddPost />} />
      <Route path="Users/:id" element={<ViewUser />} />
      <Route path="Login" element={<Login />} />
      <Route path="*" element={<NotFound />} />
    </Routes>
  );
}

export default Router;
