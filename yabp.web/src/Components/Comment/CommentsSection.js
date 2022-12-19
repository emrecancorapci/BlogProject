import {useEffect, useState} from 'react';
import axios from 'axios';
import {getToken} from '../../Functions/User';

import CommentCard from './CommentCard';
// import onDeleteComment from '../../Functions/Comment/onDeleteComment';
import getApi from '../../Functions/Common/getApi';

function CommentsSection({id}) {
  const [isLoading, setIsLoading] = useState(true);
  const [comments, setComments] = useState([]);
  const [, setToken] = useState([]);

  useEffect(() => {
    setToken(getToken());
    console.log(`ComSec ID: ${id}`);

    const api = getApi(`Posts/${id}/Comments`);

    axios(api)
        .then((response) => setComments(response.data))
        .catch((event) => console.log(event)) // Error logging
        .finally(() => setIsLoading(false)); // Set loading false
  }, []);

  return (<>
    {isLoading &&
      (<div className='spinner-border' role="status" />)}
    {<div className='d-grid gap-3 pt-2'>
      { comments.map((comment, index) => (
        <div className='row' key={index}>
          <div className='col-lg-11'>
            <CommentCard comment={comment}/>
          </div>
          {/* <Col lg={2}>
            {token &&
            (token.id === comment.authorId || token.Role === 'Admin') &&
            <>
              <Stack gap={2}>
                <Row>
                  <Button
                    variant="primary"
                    disabled>
                      Edit
                  </Button>
                </Row>
                <Row>
                  <Button
                    variant="danger"
                    onClick={() => onDeleteComment(comment.id)}>
                      Delete
                  </Button>
                </Row>
              </Stack>
            </>}
          </Col> */}
        </div>))}
    </div>}
  </>);
}

export default CommentsSection;
