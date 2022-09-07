import { useEffect, useState } from 'react';
import { Link } from "react-router-dom";
import axios from 'axios';

import Spinner from 'react-bootstrap/Spinner';

function Posts() {
    const [posts, setPosts] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const [filterText, setFilterText] = useState("");

    // FETCHING
    useEffect(() => {
        axios('https://localhost:7169/api/Posts')
            .then((response) => setPosts(response.data))
            .catch(event => console.log(event)) // Error logging
            .finally(() => setIsLoading(false)); // Set loading false
    }, []);


    // FILTER
    // On text changes at filter
    const onChangeFilter = ((event) =>
        setFilterText(event.target.value))

    const filtered = posts.filter((item) => {
        return Object.keys(item).some((key) =>
            item[key]
                .toString()
                .toLowerCase()
                .includes(filterText.toLowerCase())
        )
    });

    return (<>
        <div>
            <input
                placeholder='Filter posts'
                value={filterText}
                onChange={onChangeFilter} />
        </div>
        <br />
        <div>
            {isLoading &&
                (<Spinner animation="border" role="status">
                    <span className="visually-hidden">Loading...</span>
                </Spinner>)}

            {filtered.map((post, index) =>
                <div key={index}>
                    <Link to={`/Posts/${post.id}`}>{post.title}</Link>
                    <p>{post.postSummary}</p>
                </div>)}
        </div>
    </>)
}

export default Posts