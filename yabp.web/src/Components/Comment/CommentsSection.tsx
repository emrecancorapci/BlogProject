import { useEffect, useState } from 'react';
import axios, { AxiosResponse } from 'axios';

import AddComment from '../../Components/Comment/AddComment';
import { getToken } from '../../Functions/User';
import CommentCard from './CommentCard';
import getApi from '../../Functions/Common/getApi';
import { CommentResponse } from '../../Interfaces/CommentResponse';

const commentInitial: CommentResponse[] = [
  {
    content: '',
    authorId: 0,
    postId: 0,
    created: ''
  }
]

/**
 * @description Displays all comments for a post
 *
 * @param {string} id - Post id
 * @return {JSX.Element} All comments for a post
 */

function CommentsSection ({ postId, addPermission }: {
  postId: number
  addPermission: boolean
}): JSX.Element {
  const user = getToken();
  const [isLoading, setIsLoading] = useState(true);
  const [comments, setComments] = useState(commentInitial);

  const api = getApi(`Posts/${postId}/Comments`);

  useEffect(() => {
    const fetchComments: () => Promise<AxiosResponse> =
      async () => await axios(api);

    fetchComments()
      .then((response) => {
        if (response.status !== 200) {
          throw new Error('Error' +
            ` ${response.status}: ${response.statusText}`);
        }
        setComments(response.data)
      })
      .catch((event) => { console.log(event); }) // Error logging
      .finally(() => { setIsLoading(false); }); // Set loading false
  }, [api]);

  return (<>
    {isLoading
      ? <div className='spinner-border' role="status" />
      : (addPermission && <>
        <div className='row px-3 pt-3 pb-2 shadow-sm rounded border c-bg-lighter'>
          <h3 className='fw-bold c-tx-dark'>
            Add Comment
          </h3>
          {user !== null
            ? (<div className='pt-2'>
              <AddComment postId={Number(postId)}
                comments={comments}
                setComments={setComments} />
            </div>)
            : (<div className='alert alert-warning'>
              You must be logged in to post a comment.
            </div>)}
        </div>
        < div className='row p-2'>
          <h2 className='fw-bold c-tx-dark'>
            Comments
          </h2>
          <div className='pt-2'>
            {comments.map((comment, index) => (
              <div className='col-lg-11 mb-3' key={index}>
                <CommentCard comment={comment} />
              </div>
            ))}
          </div>
        </div>
      </>)
    }
  </>);
}

export default CommentsSection;
