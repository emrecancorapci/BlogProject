import {useEffect, useState} from 'react';
import axios from 'axios';

import PostCard from '../../Components/Post/PostCard';

function Posts() {
  // TODO Add pagination
  const [posts, setPosts] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [filterText, setFilterText] = useState('');

  useEffect(() => {
    axios('https://localhost:7169/api/Posts')
        .then((response) => setPosts(response.data))
        .catch((event) => console.log(event))
        .finally(() => setIsLoading(false));
  }, []);

  const onChangeFilter = ((event) =>
    setFilterText(event.target.value));

  const filteredPosts = posts.filter((item) => {
    return Object.keys(item).some((key) =>
      item[key]
          .toString()
          .toLowerCase()
          .includes(filterText.toLowerCase()),
    );
  });

  return (<>
    <div>
      <input
        placeholder='Search'
        value={filterText}
        onChange={onChangeFilter} />
    </div>
    {isLoading && (<div className='spinner-border' role='status'/>)}
    {<div className='d-grid gap-3 pt-3'>{filteredPosts.map((post, index) =>
      <div className='row' key={index}>
        <PostCard post={post} />
      </div>,
    )}</div>}
  </>);
}

export default Posts;
