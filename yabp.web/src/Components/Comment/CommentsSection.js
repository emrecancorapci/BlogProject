import {useEffect, useState} from 'react';
import axios from 'axios';

import CommentCard from './CommentCard';
// import onDeleteComment from '../../Functions/Comment/onDeleteComment';
import getApi from '../../Functions/Common/getApi';


/**
 * @description Displays all comments for a post
 *
 * @param {Number} id - Post id
 * @return {JSX.Element} All comments for a post
 */
function CommentsSection({id}) {
  const [isLoading, setIsLoading] = useState(true);
  const [comments, setComments] = useState([]);

  const api = getApi(`Posts/${id}/Comments`);

  useEffect(() => {
    const fetchComments = async () => await axios(api);

    fetchComments()
        .then((response) => setComments(response.data))
        .catch((event) => console.log(event)) // Error logging
        .finally(() => setIsLoading(false)); // Set loading false
  }, []);

  return (<>
    {isLoading &&
      (<div className='spinner-border' role="status" />)}
    {<div className='pt-2'>
      {comments.map((comment, index) => (
        <div className='col-lg-11 mb-3' key={index}>
          <CommentCard comment={comment}/>
        </div>
      ))}
    </div>}
  </>);
}

export default CommentsSection;
