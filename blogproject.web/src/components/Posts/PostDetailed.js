import { useEffect, useState } from "react";
import { Link, useSearchParams } from "react-router-dom";
import axios from "axios";
import Comments from "../Comments/Comments";

function PostDetailed() {
  const [isLoading, setIsLoading] = useState(true);

  const [post, setPost] = useState([]);
  const [user, setUser] = useState([]);

  const [searchParams] = useSearchParams();
  const id = searchParams.get("id") || "";

  useEffect(() => {
    axios(`https://localhost:7169/api/Posts/${id}`)
      .then((response) => setPost(response.data))
      .catch((event) => console.log(event));
  }, [id]);

  useEffect(() => {
    axios(`https://localhost:7169/api/Users/${post.authorId}`)
      .then((response) => setUser(response.data))
      .catch((event) => console.log(event))
      .finally(() => setIsLoading(false)); // Set loading false
  }, [post]);

  return (
    <>
      {isLoading && <div>Loading...</div>}
      {
        <>
          <h2>{post.title}</h2>
          <h3>Author: {user.username}</h3>
          <div>
            <p>{post.content}</p>
            <p>
              <Link to={`/post?id=${parseInt(id) - 1}`}>Previous Post</Link> |{" "}
              <Link to={`/posts`}>Posts</Link> |{" "}
            </p>
          </div>
          <Comments postId={id} />
        </>
      }
    </>
  );
}

export default PostDetailed;
