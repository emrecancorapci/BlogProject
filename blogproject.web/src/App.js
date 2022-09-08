import { Routes, Route } from "react-router-dom";
import { Container, Stack, Row, Col, Card } from 'react-bootstrap';
import './App.css';

import Posts from "./components/Posts";
import PostDetailed from "./components/Posts/PostDetailed";
import AddPost from "./components/Posts/AddPost";
import User from "./components/Users/User";
import Login from "./components/Users/Login";
import Navigation from "./components/Common/Navigation";
import SidePanel from "./components/Common/SidePanel";
import NotFound from "./components/Common/NotFound";

const title = "Yet Another Blog Project!"

function App() {
  return (
    <>
      <Stack gap={3}>
        <Row>
          <Navigation title={title} />
        </Row>
        <Container>
          <Row className="justify-content-md-center">
            <Col xl={7}>
              <Card body>
                <Routes>
                  <Route path="/" element={<Posts />} />
                  <Route path="Posts/:id" element={<PostDetailed />} />
                  <Route path="Posts/Add" element={<AddPost />} />
                  <Route path="Users/:id" element={<User />} />
                  <Route path="Login" element={<Login />} />
                  <Route path="*" element={<NotFound />} />
                </Routes>
              </Card>
            </Col>
            <Col xl={3}>
              <Row>
                <SidePanel />
              </Row>
            </Col>
          </Row>
        </Container>
      </Stack>
    </>
  );
}

export default App;
