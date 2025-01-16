import { useParams } from 'react-router';

export function UserCollection() {
  const params = useParams();

  return <div>{params.username} collection goes here</div>;
}
