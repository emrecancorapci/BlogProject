import {useEffect, useState} from 'react';
import axios from 'axios';

import PostCard from '../../Components/Post/PostCard';
import getApi from '../../Functions/Common/getApi';


/**
 * @description Displays all posts in the database
 *
 * @returns {JSX.Element} All posts in the database
 */

function Posts() {
  // TODO Add pagination
  const [posts, setPosts] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [filterText, setFilterText] = useState('');

  useEffect(() => {
    const api = getApi('Posts');

    const fetchPosts = async () => await axios(api);

    fetchPosts()
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
    {filteredPosts.map((post, index) =>
      <PostCard post={post} key={index}/>,
    )}
  </>);
}

export default Posts;
