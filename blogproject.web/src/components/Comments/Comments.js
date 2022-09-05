import { useEffect, useState } from "react";
import axios from "axios";
import AddComment from "./AddComment";
import GetUserName from "../Users/GetUserName";

function Comments({ postId }) {
  const [isLoading, setIsLoading] = useState(true);
  const [id, setId] = useState(postId);

  const [comments, setComments] = useState([]);

  // FETCHING
  useEffect(() => {
    axios(`https://localhost:7169/api/Posts/${id}/Comments`)
      .then((response) => setComments(response.data))
      .catch((event) => console.log(event)) // Error logging
      .finally(() => setIsLoading(false)); // Set loading false
  }, [id]);

  return (
    <>
      <h2>Comments</h2>
      {isLoading && <div>Loading...</div>}
      {comments.map((comment, index) => (
        <div key={index}>
          <p><GetUserName id={comment.authorId} />: {comment.content}</p>
        </div>
      ))}
      <h3>Add Comment</h3>
      <AddComment postId={id} setId={setId} />
    </>
  );
}

export default Comments;
