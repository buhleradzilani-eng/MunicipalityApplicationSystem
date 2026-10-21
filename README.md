# Municipality Application System

A Windows Forms desktop application built with C# for reporting and managing municipal infrastructure issues. Citizens can report problems such as potholes, broken streetlights, and damaged infrastructure, and the application supports issue tracking, validation, attachment handling, and gamified participation.

## What this is

**Municipality Application System** is a civic engagement platform that enables citizens to report municipal issues directly through an intuitive desktop interface. The application uses gamification mechanics to reward users for submitting complete, well-documented reports and helps municipal staff review and manage reported incidents in a structured way.

## Stack

- **Language:** C#
- **Framework / runtime:** .NET 10.0 (Windows Forms for desktop UI)
- **Key technology:** Windows Forms (WinForms), .NET Class Libraries

## How it's organized

```text
ApplicationClassLibrary/        Data model for issue management
  ├── ApplicationClassLibrary.csproj
  └── Issue.cs                 Issue entity with properties

MunicipalityApplicationSystem/  Main WinForms desktop application
  ├── MunicipalityApplicationSystem.csproj
  ├── Program.cs              Application entry point
  ├── MainForm.cs             Primary navigation form
  ├── MainForm.Designer.cs    UI designer-generated code
  ├── ReportIssueForm.cs      Form for submitting new issues
  ├── ReportIssueForm.Designer.cs
  ├── ShowIssuesForm.cs       Form for viewing submitted issues
  ├── ShowIssuesForm.Designer.cs
  ├── Properties/             Application settings and resources
  └── Resources/              UI resources

MunicipalityApplicationSystem.slnx   Solution file
```

### How it fits together

The application follows a three-form pattern:

1. **MainForm** - Serves as the entry point, providing navigation to issue reporting
2. **ReportIssueForm** - Allows users to submit new issues with:
   - Title, location, category, and description fields
   - File attachment support (images, documents)
   - Input validation on all required fields
   - Gamification rewards that award XP based on submission completeness
3. **ShowIssuesForm** - Displays all submitted issues in a formatted list view

The `Issue` class (from ApplicationClassLibrary) serves as the shared data model, storing issue metadata (title, location, category, description) and attachment paths. All issue instances are managed through the WinForms UI and displayed in the application forms.

## Data structures and algorithms in the request model

The project also demonstrates several common data structures and algorithmic patterns used for managing service requests and relationships between requests.

### 4.1 Dictionary and hash-based indexing

The `requests` field is a `Dictionary<string, ServiceRequest>` configured with `StringComparer.OrdinalIgnoreCase`. It maps a request ID to a request object and rejects duplicate IDs in `Add()`. Dictionary operations such as lookup and insertion are O(1) on average, although worst-case performance can degrade with many hash collisions.

In the supplied code, the dictionary is used for duplicate detection and checking whether requests exist before graph connections are added. `Find()` does not use the dictionary; it traverses the BST. A design improvement would be to make the dictionary the primary exact-ID lookup, or document why the BST is deliberately used for the lookup demonstration.

### 4.2 Binary tree and binary search tree (BST)

A binary tree is a hierarchical structure in which each node has no more than two children. The BST in `ServiceRequestManager` is a specialised binary tree: each node stores a request ID and request object, with smaller keys in the left subtree and larger keys in the right subtree. `InsertBst()` recursively places new requests, and `Find()` follows comparisons until the matching key is found or a null child is reached.

Example: `Find("SR-1003")` compares the ID against the root and follows either the left or right child at each step. It does not need to inspect every request if the tree is reasonably balanced.

Efficiency: a reasonably balanced BST offers average O(log n) search and insertion. Its worst case is O(n) when the tree becomes skewed, such as when IDs are inserted in sorted order. The supplied BST has no balancing rotations, so its performance depends on insertion order.

Rubric note: the BST node structure is present. A separate general-purpose binary tree and explicit traversal examples such as preorder, inorder and postorder are not shown in the excerpt. A general tree could represent municipality → department → service category → request.

### 4.3 AVL tree

`ServiceRequestManager` declares an `AvlRequestTree` and calls `avlTree.Insert(request)` whenever a request is added. An AVL tree is a self-balancing BST. It maintains node heights and uses rotations to keep the heights of the left and right subtrees close enough to ensure logarithmic height.

Example: inserting IDs in ascending order can turn an ordinary BST into a long chain. An AVL tree rebalances with rotations, so later searches do not have to traverse the entire chain.

A correctly implemented AVL tree provides O(log n) worst-case search, insertion and deletion. However, the `AvlRequestTree` source is not included in the supplied code, and `Find()` currently searches the separate BST root. Therefore, this excerpt proves that an AVL index is referenced and populated, but it does not prove that its implementation is correct or that the form uses it for retrieval. Test its rotations, duplicate handling and search behaviour separately.

### 4.4 Red-black tree and `SortedSet`

The `orderedRequests` field is a `SortedSet<ServiceRequest>`. The standard .NET `SortedSet` maintains sorted values using a balanced red-black tree internally. It provides ordered iteration and typically O(log n) add, contains and remove operations.

The supplied comparer sorts by `RequestId` without case sensitivity, then uses `GetHashCode()` as a tie-breaker. This is not a robust identity rule: hash codes are not guaranteed to remain stable between runs, and two different objects can have the same hash code. Since `Add()` already rejects duplicate request IDs, the simpler and safer approach is to compare by ID and treat equal IDs as equal, or use a deterministic unique secondary key if the domain permits duplicate IDs.

The set is populated but is not used by `GetAll()`, `Find()` or the form. Also, `SortedSet` provides a framework red-black tree implementation; it does not demonstrate a student-written red-black tree with explicit node colours, rotations and recolouring. If the assessment expects implementation of the algorithm, a separate red-black tree class is needed.

### 4.5 Heap and priority queue

`MinimumSpanningTree()` creates a `PriorityQueue<(string From, string To), int>`. A priority queue typically uses a heap to make the lowest-priority-number element available first. Enqueue and dequeue are normally O(log m), while inspecting the next priority is O(1), where m is the number of queued edges.

Prim's algorithm uses this queue to select the next lowest-weight edge that connects a visited vertex to an unvisited vertex. In the supplied code, every edge has weight 1. The priority queue therefore demonstrates the algorithm's mechanics, but it does not optimise actual distance, time or cost.

Important distinction: this is an edge-priority queue for the MST, not a heap that prioritises service requests by urgency. The code does not currently show a request-priority heap. If the rubric expects urgent requests to be displayed first, add a separate heap or priority queue using the request's `Priority` value and a tie-breaker such as submission date.

### 4.6 Queue and `HashSet`

`TraverseGraph()` uses `Queue<string>` to implement breadth-first search (BFS). A queue is first-in, first-out: the first discovered request is processed before later discoveries. The `HashSet<string>` named `visited` records IDs already discovered so that a vertex is not processed repeatedly.

The `visited` set is essential when a graph contains cycles. Without it, traversal could revisit the same requests indefinitely. Queue enqueue/dequeue operations are O(1) in typical use, and `HashSet` membership is O(1) on average.

### 4.7 Graph and request relationships

The graph is stored as `Dictionary<string, List<string>>`, where each request ID is a vertex and its list contains neighbouring request IDs. `ConnectRequests()` adds the relationship in both directions, so the graph is undirected. It verifies that both requests exist and ignores a self-connection.

For example, `SR-1001` is connected to `SR-1003`. This lets the system explore related reports. In a production system, the meaning of a connection should be explicitly defined—for example, duplicate reports about one pothole, requests assigned to a shared team, or tasks with dependencies. The sample code does not assign those meanings, so the links should be described as illustrative.

An adjacency-list graph requires O(V + E) storage, where V is the number of request vertices and E is the number of connections. Adding a connection is typically efficient, although checking a `List<string>` for a duplicate neighbour takes time proportional to that vertex's degree.

### 4.8 Breadth-first traversal (BFS)

`TraverseGraph(startId)` starts at the requested vertex, adds it to visited and enqueues it. It then repeatedly dequeues a vertex, appends it to the result and enqueues each neighbour that has not yet been visited. This explores vertices level by level.

For the supplied sample graph, traversal from `SR-1001` returns `SR-1001` and `SR-1003`. Traversal from `SR-1002` returns `SR-1002` and `SR-1005`. Traversal from `SR-1004` returns only `SR-1004` because it has no neighbours.

With an adjacency list, BFS is O(V + E) for the connected component it visits. This could help find reports related to a selected issue, provided that the application's relationship rules are meaningful.

### 4.9 Minimum spanning tree (MST) and Prim's algorithm

`MinimumSpanningTree(startId)` uses a priority queue in a Prim-style process. It marks the starting request as visited, queues its outgoing edges, and repeatedly selects an edge that reaches an unvisited vertex. Each selected edge is added to the result, and the newly visited vertex's outgoing edges are queued.

A minimum spanning tree is a minimum-total-weight set of edges connecting all vertices in a connected weighted graph without cycles. The supplied code assigns every edge a weight of 1, so all choices have equal cost. The algorithm is a demonstration, not a real optimisation of municipal travel or resources.

Because the sample graph has disconnected components, the method returns a spanning tree for the component reachable from the selected start ID, not for all five requests. Across a disconnected graph, the corresponding result is a minimum spanning forest. To make the algorithm useful, define meaningful edge weights, such as estimated shared-work cost or distance. A real road-route optimiser would need a road/intersection graph, not merely request-to-request links.

The typical heap-based Prim complexity is O((V + E) log V), subject to the graph representation and queue implementation.

### 4.10 Status history and filtering

`GetAll()` returns requests ordered by `DateSubmitted`, newest first. `GetByStatus()` filters records using a case-insensitive status comparison and also sorts newest first. The form performs similar filtering in `RefreshRequests()`. `DisplayDetails()` displays the current status, description, location, priority and `ProgressHistory`.

`UpdateStatus()` locates a request and calls `request.UpdateStatus(status)`. The `ServiceRequest` implementation should validate the allowed status values and append a timestamped history entry. The sample data uses `Submitted`, `Pending`, `In Progress` and `Completed`. The application should define the meaning of each status and the allowed transitions so that the workflow remains consistent.

## How to run it

### Prerequisites
- .NET 10.0 SDK or later
- Windows operating system (WinForms requirement)
- Visual Studio 2022+ (recommended) or any C# IDE

### Build and Run

```bash
# Clone the repository
git clone https://github.com/buhleradzilani-eng/MunicipalityApplicationSystem.git
cd MunicipalityApplicationSystem

# Build the solution
dotnet build

# Run the application
dotnet run --project MunicipalityApplicationSystem/MunicipalityApplicationSystem.csproj
```

### Features

**Reporting Issues:**
- Submit issues with required fields: title, location, category, and description
- Attach supporting files (images, documents) to issues
- Real-time file preview for image attachments
- Form validation with helpful error messages

**Gamification System:**
- Base XP (50 points) for each issue reported
- +25 XP bonus for including file attachments
- +15 XP bonus for detailed descriptions (>50 characters)
- Progress tracking toward next level (100 XP per level)

**Viewing Issues:**
- Display all submitted reports in a formatted list
- View complete issue details including attachments
- Clear list functionality

## Try asking

- How does the gamification system calculate XP rewards for different types of issue submissions?
- Where is data persistence implemented (database or file storage)?
- How can I add new categories for municipal issue types?
- What validation rules are currently applied to issue submissions?
- How can the application be extended to support user authentication and persistent storage?
