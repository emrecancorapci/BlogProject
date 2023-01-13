export interface PostResponse {
  id: number
  title: string
  postSummary: string
  content: string
  authorId: number
  isCommentsVisible: boolean
  addCommentsEnabled: boolean
}
