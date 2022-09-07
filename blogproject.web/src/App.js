import { Routes, Route } from "react-router-dom";

import Posts from "./components/Posts";
import PostDetailed from "./components/Posts/PostDetailed";
import AddPost from "./components/Posts/AddPost";
import User from "./components/Users/User";
import Login from "./components/Users/Login";
import Navigation from "./components/Common/Navigation";
import SidePanel from "./components/Common/SidePanel";

// Bootstrap
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Card from 'react-bootstrap/Card';

const title = "Yet Another Blog Project!"

function App() {
  return (
    <div className="App">
      <Container>
        <Row>
          <Navigation title={title} />
        </Row>
        <Row className="justify-content-md-center">
          <Col xl={7}>
            <Card body>
              <Routes>
                <Route path="/" element={<Posts />} />
                <Route path="Posts/:id" element={<PostDetailed />} />
                <Route path="Posts/Add" element={<AddPost />} />
                <Route path="User" element={<User />} />
                <Route path="Login" element={<Login />} />
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
    </div>
  );
}

export default App;
