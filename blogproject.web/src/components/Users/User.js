import { useEffect, useState } from 'react'
import { Link, useSearchParams } from "react-router-dom";
import axios from 'axios';

function User() {
    const [isLoading, setIsLoading] = useState(true);

    // const emptyUser = {
    //     id: 2,
    //     username: "Admin",
    //     email: "admin@admin.admin",
    //     role: "Admin",
    //     name: "Admin",
    //     lastName: "Adminson",
    //     about: "about admin string here",
    //     profilePictureUrl: "https://visualpharm.com/assets/314/Admin-595b40b65ba036ed117d36fe.svg",
    //     birthDate: "2022-09-02T12:10:19.414Z"
    // }

    const [user, setUser] = useState([]);

    const [searchParams] = useSearchParams();

    useEffect(() => {
        const id = searchParams.get('id') || '';
        axios(`https://localhost:7169/api/Users/${id}`)
            .then((response) => setUser(response.data))
            .catch(event => console.log(event))
            .finally(() => setIsLoading(false)); // Set loading false
    }, []);

    return (<>
        {isLoading && <div>Loading...</div>}
        {<>
            <div><img src={user.profilePictureUrl} /></div>
            <h1>{user.username}</h1>
            <h2>{user.name} {user.lastName}</h2>
            <p>{user.about}</p>
        </>}
    </>)
}

export default User