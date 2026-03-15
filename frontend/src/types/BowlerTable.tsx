import { useEffect, useState } from "react";

interface Bowler {
  firstName: string;
  middle: string;
  lastName: string;
  teamName: string;
  address: string;
  city: string;
  state: string;
  zip: string;
  phone: string;
}

function BowlerTable() {
  const [bowlers, setBowlers] = useState<Bowler[]>([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    fetch("/bowling")
      .then((res) => {
        if (!res.ok) {
          throw new Error(`Request failed: ${res.status}`);
        }

        return res.json();
      })
      .then((data) => setBowlers(data))
      .catch((err: Error) => setError(err.message))
      .finally(() => setIsLoading(false));
  }, []);

  if (isLoading) {
    return <p>Loading bowlers...</p>;
  }

  if (error) {
    return <p>Unable to load bowlers: {error}</p>;
  }

  return (
    <table border={1}>
      <thead>
        <tr>
          <th>Name</th>
          <th>Team</th>
          <th>Address</th>
          <th>City</th>
          <th>State</th>
          <th>Zip</th>
          <th>Phone</th>
        </tr>
      </thead>

      <tbody>
        {bowlers.map((b, index) => (
          <tr key={index}>
            <td>
              {b.firstName} {b.middle} {b.lastName}
            </td>
            <td>{b.teamName}</td>
            <td>{b.address}</td>
            <td>{b.city}</td>
            <td>{b.state}</td>
            <td>{b.zip}</td>
            <td>{b.phone}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}

export default BowlerTable;