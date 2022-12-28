import UserHover from '../User/UserHover'
import { Link } from 'react-router-dom'

/**
 * @description Displays a post card with a title, author, and summary
 *
 * @param {object} post - Post object
 * @return {JSX.Element} Post card
 */

interface Post {
  id: number
  title: string
  content: string
  authorId: number
  postSummary: string
  isCommentsVisible: boolean
  addCommentsEnabled: boolean
}

function PostCard ({ post }: { post: Post }): JSX.Element {
  return (
    <div className="card row mt-3 mx-1 p-1 shadow-sm c-bg-lighter border-0">
      <div className="card-body">
        <Link to={`/Posts/${post.id}`}>
          <div className="card-title">
            <h3 className="fw-bold">{post.title}</h3>
          </div>
        </Link>
        <div className="row pb-1">
          <div className="col-auto fw-bold c-tx-dark">
            <UserHover id={post.authorId} />
          </div>
        </div>
        <div className="card-text">{post.postSummary}</div>
        {/*
        <a href="#" class="card-link">Card link</a>
        <a href="#" class="card-link">Another link</a>
        */}
      </div>
    </div>
  )
}

export default PostCard
