import React, {useEffect, useState} from 'react';
import axios from 'axios';
import {useParams} from 'react-router-dom';
import {Row, Col, Spinner, Card} from 'react-bootstrap';

import CommentsSection from '../../Components/Comment/CommentsSection';
import UserHover from '../../Components/User/UserHover';
import AddComment from '../../Components/Comment/AddComment';

function SinglePost() {
  const [isLoading, setIsLoading] = useState(true);
  const [post, setPost] = useState([]);
  const {id} = useParams();

  useEffect(() => {
    axios(`https://localhost:7169/api/Posts/${id}`)
        .then((response) => setPost(response.data))
        .catch((event) => console.log(event))
        .finally(() => setIsLoading(false));
  }, [id]);


  return (<>
    {isLoading &&
        (<Spinner animation="border" role="status" />)}
    {<>
      <Row>
        <h1><strong>{post.title}</strong></h1>
      </Row>
      <Row>
        <Col lg="auto">
          <h5 className="text-muted"><UserHover id={post.authorId} /></h5>
        </Col>
        <Col></Col>
      </Row>
      <Card>
        <Card.Body>
          <Card.Text>{post.content}</Card.Text>
          {/* <Card.Link href="#">Card Link</Card.Link>
              <Card.Link href="#">Another Link</Card.Link> */}
        </Card.Body>
      </Card>
      {/* <div>
            <p>
              <Link to={`/Posts/${parseInt(id) - 1}`}>Previous Post</Link>
            </p>
          </div> */}
      {post.commentsEnabled && <></>}
      {<>
        <h2><strong>Comments</strong></h2>
        <CommentsSection postId={id} />
        <h3><strong>Add Comment</strong></h3>
        <AddComment postId={id} />
      </>}
    </>}
  </>);
}

export default SinglePost;
