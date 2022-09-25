import React, {useState, useEffect} from 'react';
import {Routes, Route} from 'react-router-dom';
import {Container, Stack, Row, Col, Card} from 'react-bootstrap';
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
  const title = 'Yet Another Blog Project!';

  const [auth, setAuth] = useState(false);

  useEffect(() => {
    const user = getToken();

    if (user) {
      setAuth(true);
    }
  }, [auth]);

  // Add tabs to home page
  // Posts / My Posts / New Post

  return (<>
    <Stack gap={3}>
      <Row>
        <Navigation title={title} auth={auth} setAuth={setAuth}/>
      </Row>
      <Container>
        <Row className="justify-content-md-center">
          <Col xl={7}>
            <Card body>
              <Routes>
                <Route path="/" element={<Posts />} />
                <Route path="Posts/:id" element={<SinglePost />} />
                <Route path="Posts/Add" element={<AddPost />} />
                <Route path="Users/:id" element={<User />} />
                <Route path="Login" element={<Login setAuth={setAuth} />} />
                <Route path="*" element={<NotFound />} />
              </Routes>
            </Card>
          </Col>
          <Col xl={3}>
            <Row style={{padding: '1rem'}}>
              <SidePanel />
            </Row>
          </Col>
        </Row>
      </Container>
    </Stack>
  </>);
}

export default App;
