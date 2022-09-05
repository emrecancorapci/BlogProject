import React from 'react'
import { Link } from "react-router-dom";

function Home() {
  const id = 5;

  return (
    <>
      <main>
        <h2>Welcome to the homepage!</h2>
        <p>You can do this, I believe in you.</p>
      </main>
      <nav>
        <p><Link to={`/Posts`}>Posts</Link></p>

      </nav>
    </>
  );
}

export default Home