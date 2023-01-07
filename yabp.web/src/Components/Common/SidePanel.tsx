import { Link } from 'react-router-dom';

function SidePanel (): JSX.Element {
  return (
    <ul className="list-group">
      <Link to={'/Post/Add'}>
        <li className="list-group-item">New Post</li>
      </Link>
      <li className="list-group-item">Item</li>
      <li className="list-group-item">Item</li>
      <li className="list-group-item">Item</li>
    </ul>
  );
}

export default SidePanel;
