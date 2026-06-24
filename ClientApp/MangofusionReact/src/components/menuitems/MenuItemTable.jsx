function MenuItemTable() {
    return (
        <><div className="table-center py-4">
            <div className="spinner-border" role="status">
                <span className="visually-hidden">Loading...</span>
            </div>
            <p className="mt-2">Loading menu items...</p>
        </div><div className="alert alert-danger">
                <h5>Error loading menu items</h5>
                <p>There was an error loading the menu items. Please try again later.</p>

            </div><div className="table-center py-5">
                <i className="bi bi-basket text-muted " style={{ fontSize: '3rem' }}></i>
                <h4 className=" mt-3 text-muted">No menu items found</h4>
                <p className="text-muted">start by adding a new menu item or check back later.</p>
            </div><div className="table-responsive">
                <table className="table table-hover">
                    <thead className="table-dark">
                        <tr>
                            <th scope="col">Image</th>
                            <th scope="col">Name</th>
                            <th scope="col">Category</th>
                            <th scope="col">Price</th>
                            <th scope="col"> special Tag</th>
                            <th scope="col">Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <img src="https://via.placehold.co/600x400" className="rounded"
                                    style={{ width: "60px", height: "60px", objectFit: "cover" }} />
                            </td>
                            <td><strong>Name</strong>
                                <br />
                                <small className="text-muted">DESC</small></td>
                            <td><span className="badge bg -secondary">
                                CATEGORY</span></td>
                            <td><strong>$$</strong></td>
                            <td><span className badge bg-warning text-dark>SPECIAL TAG</span></td>
                            <td>
                                <div classNmae="btn-group" role="group">
                                    <button classNmae="btn btn-sm btn-outline-danger" title="Delete">
                                        <i className="bi bi-trash"></i>
                                    </button>
                                </div>
                            </td></tr></tbody></table>
            </div></>
                                    
                
            
    );
}
export default MenuItemTable;