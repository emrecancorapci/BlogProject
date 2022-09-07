import GetUserName from "../Users/GetUserName";

import Card from 'react-bootstrap/Card';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

// TODO Implement comment delete

function CommentCard({ comment }) {
	return (
		<Card>
			<Card.Header>
				<Row>
					<Col>
						<strong className="me-auto"><GetUserName id={comment.authorId} /></strong>
					</Col>
					<Col md="auto">
						<small className="text-muted">
							{comment.created.substr(0, 10)} - {comment.created.substr(11, 8)}
						</small>
					</Col>

				</Row>
			</Card.Header>
			<Card.Body>
				<Card.Text>
					{comment.content}
				</Card.Text>
				{/* <Button variant="primary">Go somewhere</Button> */}
			</Card.Body>
			<Card.Footer className="text-muted text-center"></Card.Footer>
		</Card>
	)
}

export default CommentCard