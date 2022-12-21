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
    {<div className='pt-2'>
      { comments.map((comment, index) => (
        <div className='col-lg-11 mb-3' key={index}>
          <CommentCard comment={comment}/>
        </div>
      ))}
    </div>}
  </>);
}

export default CommentsSection;
